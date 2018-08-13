using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAccuracy : MonoBehaviour {

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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player found");
            if (goldReference.currentGold >= price && !weaponReference.accuracyUpgraded[weaponReference.currentWeapon])
            {
                goldReference.EditGold(-price);
                weaponReference.upgradeAccuracy(weaponToUpgrade);
                gameObject.GetComponentInChildren<TextMesh>().text = "Sold Out";
            }
        }
    }
}
