using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class movement : MonoBehaviour {

    public Rigidbody2D spriteBody;

    public float maxSpeed = 10;
    public float currentSpeed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        Vector2 temp = new Vector2(0,0);
        if (Input.GetKey("w"))
        {
            temp += new Vector2(0, 5);
        }
        if (Input.GetKey("s"))
        {
            temp += new Vector2(0, -5);
        }
        if (Input.GetKey("a"))
        {
            temp += new Vector2(-5, 0);
        }
        if (Input.GetKey("d"))
        {
            temp += new Vector2(5, 0);
        }
        spriteBody.velocity = temp;
    }
}
