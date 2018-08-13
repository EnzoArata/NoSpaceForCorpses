using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierItem : MonoBehaviour {

    [SerializeField] public bool isActive = false;
    [SerializeField] public GameObject host;
    [SerializeField] public float duration = 0;
    [SerializeField] public float cooldown = 0;
    private ParticleSystem ps;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if (isActive)
        {

            duration -= Time.deltaTime;
            if (duration <= 0)
            {
               isActive = false;
                host.GetComponent<ParticleSystem>().Stop();
            }
        }
	}

    public void activateItem()
    {
        isActive = true;
        duration = 8;
        cooldown = 45;
        host.GetComponent<healthSystem>().invFrames = -8;
        host.GetComponent<ParticleSystem>().Play();
    }

    public bool checkAvailable()
    {
        if (cooldown >= 0)
        {
            return false;
        }
        return true;
    }
}
