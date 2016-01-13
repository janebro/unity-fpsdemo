using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject menuCamera;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Return)) {
			player.SetActive (true);
			menuCamera.SetActive (false);
		}
	}
}
