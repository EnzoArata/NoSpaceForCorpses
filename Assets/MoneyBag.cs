using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBag : MonoBehaviour {

    public int currentGold;
    public int currentScore;
    public int highscore;
    Text score;
    public Text total;
	// Use this for initialization
	void Start () {
        currentGold = 0;
        currentScore = 0;
        score = GameObject.FindWithTag("Score").GetComponent<Text>();
    }

    public void EditGold(int changeInGold)
    {
        currentGold += changeInGold;
        if (changeInGold > 0)
        {
            Debug.Log("highscore: " + highscore);
            Debug.Log("gold: "+ currentGold);
            currentScore += changeInGold;
            highscore += changeInGold;
        }
        
        score.text = currentGold.ToString();
        //total.text = highscore.ToString();
    }
}
