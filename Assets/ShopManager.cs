using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    GameObject ShopUI;
    GameObject[] WeaponUI;
    int currentWeapon = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        WeaponUI[currentWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        ShopUI.SetActive(true);
        

    }


    public void CloseShop()
    {
        ShopUI.SetActive(false);
      
    }

    public void NextWeapon()
    {
        WeaponUI[currentWeapon].SetActive(false);
        if(currentWeapon<2)
    }
}
}
