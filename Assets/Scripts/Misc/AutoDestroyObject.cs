using UnityEngine;
using System.Collections;

public class AutoDestroyObject : MonoBehaviour {
    public float time;
	
	void Start () {
        Destroy(gameObject, time);
	}
}
