using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    //[SerializeField] Sprite playerSprite;
    GameObject Player;
    [SerializeField] public Sprite mySprite;
    public Sprite soldierGun;
    public Sprite soldierRifle;
    public Sprite soldierMachine;
    public Sprite soldierStand;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player = GameObject.Find("Player");
        mySprite = GameObject.Find("mySprite").GetComponent<SpriteRenderer>().sprite;
        //Player.GetComponent<SpriteRenderer>().sprite =
        //Debug.Log(Player.GetComponent<Shoot>().getCurrentWeapon);
        switch (Player.GetComponent<Shoot>().getCurrentWeapon)
        {
            case 0:
                GameObject.Find("mySprite").GetComponent<SpriteRenderer>().sprite = soldierGun;
                break;
            case 1:
                GameObject.Find("mySprite").GetComponent<SpriteRenderer>().sprite = soldierRifle;
                break;
            case 2:
                GameObject.Find("mySprite").GetComponent<SpriteRenderer>().sprite = soldierMachine;
                break;
            default:
                GameObject.Find("mySprite").GetComponent<SpriteRenderer>().sprite = soldierStand;
                break;


        }
        //playerSprite = Resources.Load("soldier1_machine", typeof(Sprite)) as Sprite;
    }
}
