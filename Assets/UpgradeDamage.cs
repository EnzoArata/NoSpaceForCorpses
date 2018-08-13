using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : MonoBehaviour {

    public Shoot weaponReference;
    public MoneyBag goldReference;
    private int shopLevel = 1;
    [SerializeField] public int weaponToUpgrade;
    [SerializeField] public int pricePerLevel;
    // Use this for initialization
    void Start()
    {
        weaponReference = GameObject.FindWithTag("Player").GetComponent<Shoot>();
        goldReference = GameObject.FindWithTag("Player").GetComponent<MoneyBag>();
        gameObject.GetComponentInChildren<TextMesh>().text = pricePerLevel.ToString();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player found");
            if (goldReference.currentGold >= pricePerLevel * shopLevel)
            {
                goldReference.EditGold(-pricePerLevel * shopLevel);
                weaponReference.upgradeWeaponDamage(weaponToUpgrade);
                shopLevel++;
                gameObject.GetComponentInChildren<TextMesh>().text = (pricePerLevel*shopLevel).ToString();
            }
        }
    }
}
