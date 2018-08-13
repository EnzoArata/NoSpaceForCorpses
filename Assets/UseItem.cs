using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {

    [SerializeField] public GameObject host;
    [SerializeField] public GameObject decoyRef;
    public int[] itemTags; //an array that holds all the information of the active items that you may have
    /*
     *  0 = Barrier
     */

    [SerializeField] public int currentItem = 0; //the current item selected

	// Use this for initialization
	void Start () {
        currentItem = 1;
	}
	
	// Update is called once per frame
	void Update () {

        //revise this later
        if (Input.GetKeyDown("2"))
        {
            if (host.GetComponent<BarrierItem>().checkAvailable())
            {
                host.GetComponent<BarrierItem>().activateItem();
            }
        }
        if (Input.GetKeyDown("3"))
         {
             if (decoyRef.GetComponent<DeplorDecoy>().checkAvailable())
             {
                 decoyRef.GetComponent<DeplorDecoy>().activateItem(Camera.main.ScreenToWorldPoint(Input.mousePosition));
             }
        }
                    
	}
}
