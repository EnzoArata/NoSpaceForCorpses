using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClip : MonoBehaviour {

    public Shoot weaponReference;
    public MoneyBag goldReference;
    [SerializeField] public int weaponToUpgrade;
    [SerializeField] public int price;
	// Use this for initialization
	void Start () {
        weaponReference = GameObject.FindWithTag("Player").GetComponent<Shoot>();
        goldReference = GameObject.FindWithTag("Player").GetComponent<MoneyBag>();
        gameObject.GetComponentInChildren<TextMesh>().text = price.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
       
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player found");
            if (goldReference.currentGold >= price && !weaponReference.clipUpgraded[weaponReference.currentWeapon])
            {
                goldReference.EditGold(-price);
                weaponReference.upgradeClip(weaponToUpgrade);
                gameObject.GetComponentInChildren<TextMesh>().text = "Sold Out";
            }
        }
    }
}
