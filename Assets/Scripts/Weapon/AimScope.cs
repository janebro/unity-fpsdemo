using UnityEngine;
using System.Collections;

public class AimScope : MonoBehaviour {

	public GameObject[] weapons;
	public GameObject playerCAM;

	void Update ()
	{
		if(Input.GetMouseButton(1)) 
		{
			switch (weapons[0].name) 
			{
			case "acr_rifle":
				transform.localPosition = new Vector3 (-0.224f, 0f, 0f);
				break;
			case "Assault Rifle":
				transform.localPosition = new Vector3 (0.1f, 0f, 0f);
				playerCAM.GetComponent<Camera> ().fieldOfView = 30f;
				break;
			default:
				break;
			}
		} 
		else 
		{
			switch (weapons[0].name) 
			{
			case "acr_rifle":
				transform.localPosition = Vector3.zero;
				break;
			case "Assault Rifle":
				transform.localPosition = new Vector3 (0.2f, 0f, 0f);
				playerCAM.GetComponent<Camera> ().ResetFieldOfView ();
				break;
			default:
				break;
			}
		}
	}
}