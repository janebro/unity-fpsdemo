using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	void Update()
	{
		
	}

	void PlayHoverSound()
	{
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}
