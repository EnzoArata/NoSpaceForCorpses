using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WraithAI : MonoBehaviour
{

    [SerializeField] public Transform target; //Reference to the player mostly; change with decoy?
    [SerializeField] public float speed = 2.5f; //Speed of the zombo
    [SerializeField] public float lifespan; //Lifespan if we want to use it; maybe for explosive enemies? (Not used)
    [SerializeField] public GameObject corpse; //The type of corpse we drop
    [SerializeField] public GameObject spriteRef;
    [SerializeField] public float health = 25f; //Health
    [SerializeField] public GameObject hitEffect;
    [SerializeField] public GameObject zombieRef;
    [SerializeField] public GameObject fastRef;
    [SerializeField] public GameObject mongoRef;
    [SerializeField] public GameObject wumboRef;
  

    private waveManager WaveManager;

    Text score;
    int goldTemp;
    // Use this for initialization
    void Start()
    {
        //gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(100, 0, 0);
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(health / 100f, health / 100f, 1, 1);
        target = GameObject.FindWithTag("Player").transform;
        score = GameObject.FindWithTag("Score").GetComponent<Text>();
        WaveManager = GameObject.Find("ZombieSpawner").GetComponent<waveManager>();

        //health = 100;
        //speed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            WaveManager.KillWraith();
            int.TryParse(score.text, out goldTemp);
            goldTemp += Random.Range(1, 6);
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Corpse")
        {
            Instantiate(zombieRef, gameObject.transform);
            Destroy(col.gameObject);
            /* if (col.gameObject.name == "CorpseObject")
             {
                 Instantiate(zombieRef, col.transform);
                 WaveManager.currentZombies++;
                 WaveManager.RemainingZombies++;
             }
             else if (col.gameObject.name == "FastCorpse")
             {
                 Instantiate(fastRef, col.transform);
                 WaveManager.currentFastZombies++;
                 WaveManager.RemainingFastZombies++;
             }
             else if (col.gameObject.name == "MongoObject")
             {
                 Instantiate(mongoRef, col.transform);
                 WaveManager.currentMongoZombies++;
                 WaveManager.RemainingMongoZombies++;
             }
             else if (col.gameObject.name == "WumboObject")
             {
                 Instantiate(wumboRef, col.transform);
                 WaveManager.currentWumboZombies++;
                 WaveManager.RemainingWumboZombies++;
             }*/
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
}
