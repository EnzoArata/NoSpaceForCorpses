using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpseBehavior : MonoBehaviour {

    [SerializeField] public float lifespan; //Lifespan of the corpse; should be lengthy
    //[SerializeField] public float corpseParent; //Parent of the corpse, used to align it
    [SerializeField] public GameObject corpseEffect; //Use for cool stuff
    [SerializeField] public Transform target;
    private Vector3 targetPos;
    private bool playOnce = true;
    [SerializeField] public bool isThrown = false;
    public GameObject fireEffect; //Need a second variable to store the particle effect; this is what's deleted instead
    private float thrownLife = 0;
    private float thrownSpeed = 7;
    public bool isDangerous = false;

	// Use this for initialization
	void Start () {
        lifespan = 15;
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        //lifespan -= Time.deltaTime;
        if (playOnce && lifespan <= 10)
        {
            playOnce = false;
            fireEffect = Instantiate(corpseEffect, transform.position, transform.rotation);
        }
        if (lifespan < 0)
        {
            Destroy(fireEffect);
            Destroy(gameObject);
        }
        if(!playOnce)
        {
            fireEffect.transform.position = transform.position;
        }
        if (isThrown && thrownLife >= 0)
        {
            thrownLife -= Time.deltaTime;
            float step = thrownSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, step);
            if (thrownLife <= 0 || this.transform.position == targetPos)
            {
                isThrown = false;
                isDangerous = false;
            }
        }

	}

    public void setThrown(Vector3 initPos, Quaternion initRot)
    {
        isThrown = true;
        isDangerous = true;
        thrownLife = 1;
        targetPos = target.position;
    }

    public bool checkDangerous()
    {
        return isDangerous;
    }
}
