using UnityEngine;
using System.Collections;
using UnityEngine.UI; // para poder ter acesso aos elementos de UI.

public class WeaponBehaviourScript : MonoBehaviour {

    //public GameObject bullet;
    public float weaponDamage;
    public int magSize, totalMags, currentMags; //magSize = quantidade total de munição em um cartucho; totalMags = Quantidade total de cartuchos; CurrentMags = quantidade atual de cartuchos.
    public AudioClip fireSound, magEmpty;
    public GameObject bulletHole;
    public GameObject bloodSplash;
    public WeaponAnimationsScript animationsRef;

	public Text balaText; // quantidade de balas mostrada no hud; 
	public Text penteText; // quantidade de pentes mostrada no hud;

    public GameObject muzzleSpot;
    public LayerMask mask; //Uma layermask. Tudo que tiver selecionado no Inspector vai ser ignorado.

    private int totalBullets, currentBullets; //totalBullets = quantidade total de balas no momento; currentBullets = quantidade de balas no atual cartucho da arma.

    //Componentes
    private AudioSource audioSrc;
    private ParticleSystem muzzParticleSys;
    /*  
    if (Input.GetMouseButton(0))
    Botão esquerdo do mouse.
        
    if (Input.GetMouseButton(1))
    Botão direito do mouse.
        
    if (Input.GetMouseButton(2))
    Botão do meio do mouse.
    * 
    */

    void Start()
    {
        totalBullets = magSize * currentMags;
        currentBullets = magSize;
        audioSrc = GetComponent<AudioSource>();
        muzzParticleSys = muzzleSpot.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && animationsRef.reloading == false && animationsRef.drawWeapon == false && animationsRef.shooting == false && currentBullets > 0)
        {
            //Instantiate(bullet, transform.position, transform.rotation);
            audioSrc.PlayOneShot(fireSound); //Dispara o som de tiro
            muzzParticleSys.Play(); //Dispara a animação de muzzle flash.

            StartCoroutine(animationsRef.Fire()); //Dispara a animação de atirar.
            currentBullets--; //Decrementa em um a quantidade de balas.

            RayCastShoot(); //Chama método para fazer o raycast;
        }

        if (Input.GetMouseButtonDown(0) && currentBullets <= 0)
        {
            audioSrc.PlayOneShot(magEmpty); //Dispara o som de cartucho vazio.
        }

        if (Input.GetKeyDown("r") && animationsRef.reloading == false && animationsRef.drawWeapon == false && currentMags > 0)
        {
            currentBullets = magSize; //"Recarrega" a variável de quantidade atual de balas.
            currentMags--; //Decrementa em um a quantidade de cartuchos que temos.

            StartCoroutine(animationsRef.Reloading());
        }

        if (Input.GetKeyDown("1") && animationsRef.reloading == false)
        {
            StartCoroutine(animationsRef.DrawWeapon());
        }
    }

    public void RayCastShoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Cria o raycast do centro da tela.

        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            switch (hit.collider.tag)
            {
                case "Enemy":
                    Instantiate(bloodSplash, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    hit.collider.GetComponentInParent<EnemyStats>().health -= weaponDamage; //Diminui a vida do inimigo.
                    break;
                default:
                    Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    break;
            }
            
            //print(hit.collider.tag);
        }
    }

	void LateUpdate()
	{
		hudControler ();
	}

	private void hudControler() //seta a quantidade de balas/pentes no objeto de texto
	{
		balaText.text = "" + currentBullets.ToString(); 
		penteText.text = "" + currentMags.ToString();
	}

}
