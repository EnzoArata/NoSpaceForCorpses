using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animator : MonoBehaviour {
	int frames=2;
	int framesPerSecond =4;

	public Image coinPile;
	 
	void Update() {
	    float index = (Time.time * framesPerSecond) % frames;
	    Mathf.RoundToInt(index);
	    //Debug.Log(index);
	    if(index < 1){
	    	coinPile.enabled = true;
	    }
	    else{
	    	coinPile.enabled = false;
	    }
	}
}