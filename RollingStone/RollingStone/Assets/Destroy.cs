﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "MovingPlane")
        {
            Destroy(hit.gameObject);
        }
    }
}
