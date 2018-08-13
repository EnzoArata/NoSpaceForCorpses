using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour {

    public float offset;
    public Transform target;
    public bool TargetMouse = true;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 difference;
        if (TargetMouse)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        else
        {
            difference = target.position - transform.position;
        }
            
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
