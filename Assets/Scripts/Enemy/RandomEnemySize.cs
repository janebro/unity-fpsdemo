using UnityEngine;
using System.Collections;

public class RandomEnemySize : MonoBehaviour {
    
    public float scaleMin, scaleMax;

    private Vector3 newScale;
	// Use this for initialization
	void Start () {
	    
        float newXYZ = Random.Range(scaleMin, scaleMax);
        newScale = new Vector3(newXYZ, newXYZ, newXYZ);

        transform.localScale = newScale;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
