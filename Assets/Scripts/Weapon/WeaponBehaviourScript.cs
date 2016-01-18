using UnityEngine;
using System.Collections;

public class WeaponBehaviourScript : MonoBehaviour {

    //public GameObject bullet;
    public AudioClip fireSound;
    public GameObject bulletHole;
    public WeaponAnimationsScript animationsRef;

    public GameObject muzzleSpot;
    public LayerMask mask; //Uma layermask. Tudo que tiver selecionado no Inspector vai ser ignorado.

    void Update()
    {
        if (Input.GetMouseButton(0) && animationsRef.reloading == false && animationsRef.drawWeapon == false && animationsRef.shooting == false)
        {
            //Instantiate(bullet, transform.position, transform.rotation);
            GetComponent<AudioSource>().PlayOneShot(fireSound); //Dispara o som de tiro
            muzzleSpot.GetComponent<ParticleSystem>().Play(); //Dispara a animação de muzzle flash.

            StartCoroutine(animationsRef.Fire()); //Dispara a animação de atirar.

            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Cria o raycast do centro da tela.

            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }


        if (Input.GetKeyDown("r") && animationsRef.reloading == false && animationsRef.drawWeapon == false)
        {
            StartCoroutine(animationsRef.Reloading());
        }

        if (Input.GetKeyDown("1") && animationsRef.reloading == false)
        {
            StartCoroutine(animationsRef.DrawWeapon());
        }
    }
}
