﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSniperMove : MonoBehaviour {

    public float speed = 5.0f;
    public float stamina = 10.0f;
    Rigidbody2D  rigidbody2D;
    public float distanceTravelled = 0;
    Vector3 startingPosition;
    private float x;
    private float y;
    private bool canMove = false;
    private bool selected = false;
    public bool alive = true;
    // Use this for initialization
    void Start () {
        //Retrieve and store the players starting position
        rigidbody2D = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
}
	
    private static void Movement(Rigidbody2D rigidbody2D, float x, float y, float speed)
    {
        //Move the character.
        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;
    }
	// Update is called once per frame
	void Update () {
        
        distanceTravelled = Vector3.Distance(startingPosition, transform.position);

        if (distanceTravelled > stamina)
        {
            canMove = false; 
        }

        if (canMove == true)
        {

            float x = Input.GetAxis("Horizontal") * 0.25f;
            float y = Input.GetAxis("Vertical") * 0.25f;
            Movement(rigidbody2D, x, y, speed);
        }

        if (canMove == false)
        {
            x = 0;
            y = 0;
        }


        
    }

    private void MyTurn()
    {
        if (alive == true)
        {
            selected = true;
            canMove = true;
            startingPosition = transform.position;
        }
    }

    //private void OnMouseDown()
    //{
    //    if (selected == true)
    //    {
    //         print("Player Passive End Turn");
    //         selected = false;
    //         GameObject.Find("TurnMaster").SendMessage("PSniperDone", SendMessageOptions.DontRequireReceiver);
    //    }
       
    //}
}
