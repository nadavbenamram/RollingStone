using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

	private float m_Timer = 0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		m_Timer -= Time.deltaTime;
		if (m_Timer < 0) {
			Application.Quit();
		}
	}


}
