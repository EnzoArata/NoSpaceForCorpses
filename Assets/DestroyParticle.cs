using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Delete", 0.1f);
	}
	
	// Update is called once per frame
	void Delete () {
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
	}
}
