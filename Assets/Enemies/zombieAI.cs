using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombieAI : MonoBehaviour {

    [SerializeField] public Transform target; //Reference to the player mostly; change with decoy?
    [SerializeField] public float speed = 5; //Speed of the zombo
    [SerializeField] public float lifespan; //Lifespan if we want to use it; maybe for explosive enemies? (Not used)
    [SerializeField] public GameObject corpse; //The type of corpse we drop
    [SerializeField] public GameObject spriteRef;
    [SerializeField] public float health = 100; //Health
    [SerializeField] public GameObject hitEffect;
    [SerializeField] public MoneyBag goldRefrence;
    //[SerializeField] GameObject Manager;
    private waveManager WaveManager;

    Text score;
    //public int totalGold;
    public int goldTemp;
	// Use this for initialization
	void Start () {
        //totalGold = 0;
        goldRefrence = GameObject.FindWithTag("Player").GetComponent<MoneyBag>();
        target = goldRefrence.transform;
        score = GameObject.FindWithTag("Score").GetComponent<Text>();
        WaveManager = GameObject.Find("ZombieSpawner").GetComponent<waveManager>();

        //health = 100;
        //speed = 5;
    }
	
	// Update is called once per frame
	void Update () {

        //changeHealth(20 * Time.deltaTime);

        if (health <= 0)
        {
            //reference the corpse to see what the zombie is
            if (corpse.name == "FastCorpse")
            {
                WaveManager.KillFast();
            }
            else if (corpse.name == "MongoCorpse")
            {
                WaveManager.KillMongo();
            }
            else if (corpse.name == "WumboCorpse")
            {
                WaveManager.KillWumbo();
            }
            else
            {
                WaveManager.KillZombie();
            }
            
            int.TryParse(score.text, out goldTemp);
            int addedGold = Random.Range(5, 15);
            goldTemp += addedGold;
            goldRefrence.EditGold(addedGold);
            //totalGold += Random.Range(1, 6);

            Debug.Log("New gold total: " + goldTemp);
            score.text = goldTemp.ToString();

            Instantiate(corpse, transform.position, spriteRef.transform.rotation);
            Destroy(gameObject);
        }
		if (this.transform.position != target.position)
        {
            float step = speed * Time.deltaTime;

            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, step);
        }

	}

    //Call to decrease the health of the zombie from any source
    //Use negative damage to heal, and positive damage to hurt
    public void changeHealth(float damage)
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        health -= damage;
    }

    public void changeTarget(Transform newTarget)
    {
        target = newTarget;
    }
    //resets to player target
    public void revertTarget()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    public void OnTriggerExit(Collider col)
    {
        changeTarget(GameObject.FindWithTag("Player").transform);
    }
}
