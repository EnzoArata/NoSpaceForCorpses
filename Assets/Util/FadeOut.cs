using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public float waitTime = 4.0f;
    public Text text;
    bool runOnce;
    float elapseTime;

    void Update(){
		elapseTime += Time.deltaTime;
    	
    	if(elapseTime > waitTime){
    		StartCoroutine(FadeTextToZeroAlpha(5.0f, text));
    	}
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        //runOnce = false;
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public void resetwaitTime(){
        StartCoroutine(FadeTextToFullAlpha(10.0f, text));
        waitTime = 10.0f;
    }
}
