using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
	public GameObject bulletHole;

	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate(bullet, transform.position, transform.rotation);
            GetComponent<AudioSource>().Play();
			GetComponent<ParticleSystem>().Play();

			RaycastHit hit;
			Ray ray = new Ray (transform.position, transform.forward);

			if (Physics.Raycast(ray, out hit, 100f)) 
			{
				Instantiate (bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
			}
        }
	}
}
