﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, 50));
	}
}
