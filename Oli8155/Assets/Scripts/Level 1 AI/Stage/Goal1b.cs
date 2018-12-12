using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal1b : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D()
    {
        print("Goal Reached");
        Application.LoadLevel("Stage1Complete");
    }

}
