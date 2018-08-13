using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectColliders : MonoBehaviour {

    //public CircleCollider2D setToTrigger;
    private waveManager WaveManager;
    public zombieAI zombiePointer;
    //public Transform bombPreFab;



    void Start()
	{
        WaveManager = GameObject.Find("ZombieSpawner").GetComponent<waveManager>();
        Invoke ("detonate", 2.0f);
	}

	public void detonate(){
		Vector2 explosionPosition = transform.position;
		float explosionRadius = 2;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, explosionRadius);
		Debug.Log(colliders.Length);
        
		for(int i=0;i< colliders.Length;i++)
        { 
            if (colliders[i].tag == "Enemy")
            {
               zombiePointer =  colliders[i].GetComponent<zombieAI>(); 
               zombiePointer.changeHealth(85);
            }
            if (colliders[i].tag == "Corpse")
		    {
		        Destroy(colliders[i].gameObject);
		    }
           
	    }
        //var cloneBomb = Instantiate(bombPreFab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

	/*void OnTriggerEnter2D(Collider2D col){
		Debug.Log("YOOOO");
		Destroy(this);
	}*/
}
