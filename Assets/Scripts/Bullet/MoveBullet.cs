﻿using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

    public float speed = 1f;
		
	void Update () {
        transform.Translate(0, 0, speed);
	}
}
