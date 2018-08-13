using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour {

    [SerializeField] public GameObject hitEffect;
    [SerializeField] public float playerHealth = 100;
    [SerializeField] public float invFrames = 1; //The time we get as invulnerable inbetween hits

    public Slider health;
    public Text health_UI;

	// Use this for initialization
	void Start () {
        //playerHealth = 100;
        //invFrames = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(invFrames < 1)
        {
            invFrames += Time.deltaTime;
        }
		if (playerHealth <= 0)
        {
            //do something
            print("Should die here");
            //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "You have Died");
         
            
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            
            
        }
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && invFrames >= 1)
        {
            if (col.gameObject.name =="MongoZombo")
            {
                changeHealth(-40);
                health.value = playerHealth;
                health_UI.text = playerHealth.ToString();
                invFrames = 0;
            }
            else if( col.gameObject.tag == "WumboZombo")
            {
                changeHealth(-80);
                health.value = playerHealth;
                health_UI.text = playerHealth.ToString();
                invFrames = 0;
            }
            else
            {
                changeHealth(-20);
                health.value = playerHealth;
                health_UI.text = playerHealth.ToString();
                invFrames = 0;
            }
                      
        }
        else if (col.gameObject.name == "CorpseObject"  || col.gameObject.name == "FastCorpse")
        {
            if (col.gameObject.GetComponent<corpseBehavior>().checkDangerous()) //check to see if the corpse is active
            {
                changeHealth(-15);
                health.value = playerHealth;
                health_UI.text = playerHealth.ToString();
                invFrames = 0;
            }   
           
        }
    }

    //Used to change health. positive heals, negative subtracts
    void changeHealth(float changeVal)
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        playerHealth += changeVal;
    }
     
}
