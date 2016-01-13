using UnityEngine;
using System.Collections;

public class BulletHole : MonoBehaviour {

	public float delayTime = 10f;

	void Update ()
	{
		Destroy(gameObject, delayTime);
	}
}
