﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("SAS");
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hitting wall");
        }
    }
}
