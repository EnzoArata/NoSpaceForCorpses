using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] GameObject Manager;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    private void Update()
    {
        waveManager WaveManager = Manager.GetComponent<waveManager>();
        if (Object.name == "Zombie")
        {
            if (timeBtwSpawns <= 0 && WaveManager.currentZombies < WaveManager.RemainingZombies)
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(Object, transform);
                WaveManager.currentZombies++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        else if (Object.name == "MongoZombo")
        {
            if (timeBtwSpawns <= 0 && WaveManager.currentMongoZombies < WaveManager.RemainingMongoZombies)
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(Object, transform);
                WaveManager.currentMongoZombies++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        else if (Object.name == "FastZombie")
        {
            if (timeBtwSpawns <= 0 && WaveManager.currentFastZombies < WaveManager.RemainingFastZombies)
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(Object, transform);
                WaveManager.currentFastZombies++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        else if (Object.name == "AngryZombie")
        {
            if (timeBtwSpawns <= 0 && WaveManager.currentAngryZombies < WaveManager.RemainingAngryZombies)
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(Object, transform);
                WaveManager.currentAngryZombies++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        else if (Object.name == "MongoZombo")
        {
            if (timeBtwSpawns <= 0 && WaveManager.currentWumboZombies < WaveManager.RemainingWumboZombies)
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(Object, transform);
                WaveManager.currentWumboZombies++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        else if (Object.name == "Wraith")
        {
            if (timeBtwSpawns <= 0 && WaveManager.currentWraithZombies < WaveManager.RemainingWraithZombies)
            {
                //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                //camAnim.SetTrigger("shake");
                Instantiate(Object, transform);
                WaveManager.currentWraithZombies++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }



    }
}
