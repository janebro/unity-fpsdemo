using UnityEngine;
using System.Collections;

public class AimScope : MonoBehaviour {

	public GameObject[] weapons;
	public GameObject playerCAM;

    public Vector3 weaponScopePosition;
    public float zoomAmount;

    private Vector3 weaponDefaultPosition;
    private float defaultFOV;
    private Camera cam;

    void Start()
    {
        cam = playerCAM.GetComponent<Camera>();
        weaponDefaultPosition = transform.localPosition;
        defaultFOV = cam.fieldOfView;
    }

	void Update ()
	{

        /*  if (Input.GetMouseButton(0))
            Botão esquerdo do mouse.
        
            if (Input.GetMouseButton(1))
            Botão direito do mouse.
        
            if (Input.GetMouseButton(2))
            Botão do meio do mouse.
         * 
         */

        if (Input.GetMouseButton(1))
        {
            transform.localPosition = weaponScopePosition;
            cam.fieldOfView = zoomAmount;
        }
        else
        {
            transform.localPosition = weaponDefaultPosition;
            cam.fieldOfView = defaultFOV;
        }

        //if(Input.GetMouseButton(1))//Apertar botão direito.
        //{
        //    switch (weapons[0].name) 
        //    {
        //    case "acr_rifle":
        //        transform.localPosition = new Vector3 (-0.224f, 0f, 0f);
        //        break;
        //    case "Assault Rifle":
        //        transform.localPosition = new Vector3(-0.098f, 0.014f, 0f);
        //        playerCAM.GetComponent<Camera>().fieldOfView = 30f;
        //        break;
        //    default:
        //        break;
        //    }
        //} 
        //else //Soltar botão direito;
        //{
        //    switch (weapons[0].name) 
        //    {
        //    case "acr_rifle":
        //        transform.localPosition = Vector3.zero;
        //        break;
        //    case "Assault Rifle":
        //        //transform.localPosition = new Vector3 (0.2f, 0f, 0f);
        //        transform.localPosition = weaponDefaultPosition;
        //        playerCAM.GetComponent<Camera>().fieldOfView = defaultFOV;
        //        break;
        //    default:
        //        break;
        //    }
        //}
	}
}