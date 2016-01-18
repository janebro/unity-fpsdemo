using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    //public GameObject bullet;
    public AudioClip fireSound;
	public GameObject bulletHole;
    public WeaponAnimationsScript animationsRef;

    public GameObject muzzleSpot;
    public LayerMask mask; //Uma layermask. Tudo que tiver selecionado no Inspector vai ser ignorado.

	void Update () {
        if (Input.GetButtonDown("Fire1") && animationsRef.reloading == false && animationsRef.drawWeapon == false)
        {
            //Instantiate(bullet, transform.position, transform.rotation);
            GetComponent<AudioSource>().PlayOneShot(fireSound);
			muzzleSpot.GetComponent<ParticleSystem>().Play ();

			RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Cria o raycast do centro da tela.

            if (Physics.Raycast(ray, out hit, 100f, mask))
			{
               Instantiate (bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}
        }
	}
}
