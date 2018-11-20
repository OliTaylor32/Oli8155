﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        while (transform.localScale.x < 0.8)
        {
            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        }
            
    }

    void OnMouseExit()
    {
        while (transform.localScale.x > 0.8)
        {
            transform.localScale += new Vector3(-0.1F, -0.1f, -0.1f);
        }
    }

    private void OnMouseDown()
    {
        Application.LoadLevel("OpeningCutscene");
    }

}
