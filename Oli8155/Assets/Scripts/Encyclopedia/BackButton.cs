﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //Grow in size when mouse is hovering over
    void OnMouseOver()
    {
        while (transform.localScale.x < 0.8)
        {
            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        }
            
    }
    //When the mouse exits, 
    void OnMouseExit()
    {
        while (transform.localScale.x > 0.8)
        {
            transform.localScale += new Vector3(-0.1F, -0.1f, -0.1f);
        }
    }
    //When Clicked, load the main menu
    private void OnMouseDown()
    {
        Application.LoadLevel("Main Menu");
    }

}
