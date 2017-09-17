using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    int index = 0;
    bool isIn = false;
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "MovingPlane")
        {
            if (!isIn)
            {

                if (hit.transform.name.Contains("MovingPlane"))
                { 
                     index++;
                     Instantiate(Resources.Load("MovingPlane"));
                      Debug.Log(">>" + hit.transform.name);
                     isIn = true;
                }
            }
        }
    }

    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.tag == "MovingPlane")
        {
            if (hit.transform.name.Contains("MovingPlane"))
            {
                isIn = false;
            }
        }
    }
 }
