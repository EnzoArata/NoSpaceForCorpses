using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveManager : MonoBehaviour {
    public int CurrentWave;


    [SerializeField] public int RemainingZombies;
    [SerializeField] public int currentZombies;
    [SerializeField] public int waveMultiplier;
    [SerializeField] public bool waiting;
    [SerializeField] public Transform shopTeleport;
    [SerializeField] public int RemainingFastZombies;
    [SerializeField] public int currentFastZombies;
    [SerializeField] public int RemainingMongoZombies;
    [SerializeField] public int currentMongoZombies;
    [SerializeField] public int RemainingAngryZombies;
    [SerializeField] public int currentAngryZombies;
    [SerializeField] public int RemainingWumboZombies;
    [SerializeField] public int currentWumboZombies;
    [SerializeField] public int currentWraithZombies;
    [SerializeField] public int RemainingWraithZombies;

    public Vector2 playersOriginalLocation;
    bool inShop = false;
    public movement playerReference;
    public float waitTime;

    //added by Ben
    //Adding text that displays current wave on UI
    public Text CurrentWave_UI;
    public Text tabMessage_UI;
    public Text timeTillStart_UI;
    public Text TillStart_UI;

    public FadeOut script;
    
    
	// Use this for initialization
	void Start () {
		timeTillStart_UI.enabled = false;
        TillStart_UI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (RemainingZombies <= 0 && RemainingAngryZombies <= 0 && RemainingFastZombies <= 0 && RemainingMongoZombies <= 0 && RemainingWumboZombies <= 0  && RemainingWraithZombies <= 0)
        {
            waitTime -= Time.deltaTime;

            
            playerReference = GameObject.FindWithTag("Player").GetComponent<movement>();
            if (!(inShop))
            {
                playersOriginalLocation = playerReference.transform.position;
                playerReference.transform.position = shopTeleport.transform.position;
                inShop = true;
            }
            if (waiting)
            {
                TillStart_UI.enabled = false;
                timeTillStart_UI.enabled = false;

                tabMessage_UI.enabled = true;
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    TillStart_UI.enabled = true;
                    tabMessage_UI.enabled = false;
                    waiting = false;

                    playerReference.transform.position = playersOriginalLocation;
                    waitTime = 10f;

                }
            }

            if(!waiting && waitTime > 0){
                TillStart_UI.enabled = true;
                timeTillStart_UI.enabled = true;
                timeTillStart_UI.text = waitTime.ToString();
            }

            if (!waiting && waitTime <=0)
            {
                TillStart_UI.enabled = false;
                timeTillStart_UI.enabled = false;
                script.resetwaitTime();
                tabMessage_UI.enabled = false;
                inShop = false;
                CurrentWave++;
                CurrentWave_UI.text = CurrentWave.ToString();
                RemainingZombies = CurrentWave * waveMultiplier;
                RemainingMongoZombies = (CurrentWave - 2) * 2;
                RemainingAngryZombies = (CurrentWave - 4) * 2;
                RemainingFastZombies = (CurrentWave - 6) * 2;
                if (CurrentWave % 10 == 0)
                {
                    RemainingWumboZombies = 1;
                }
                if (CurrentWave % 5 == 0)
                {
                    RemainingWraithZombies = 1;
                }
                currentZombies = 0;
                currentWraithZombies = 0;
                currentFastZombies = 0;
                currentWumboZombies = 0;
                currentMongoZombies = 0;
                currentAngryZombies = 0;
                waiting = true;

            }

        }
        else{
            timeTillStart_UI.enabled = false;
        }
	}

    public void KillZombie()
    {
        currentZombies--;
        RemainingZombies--;
    }

    public void KillMongo()
    {
        currentMongoZombies--;
        RemainingMongoZombies--;
    }
    public void KillFast()
    {
        currentFastZombies--;
        RemainingFastZombies--;
    }
    public void KillAngry()
    {
        currentAngryZombies--;
        RemainingAngryZombies--;
    }
    public void KillWumbo()
    {
        currentWumboZombies--;
        RemainingWumboZombies--;
    }

    public void KillWraith()
    {
        currentWraithZombies--;
        RemainingWraithZombies--;
    }
}
