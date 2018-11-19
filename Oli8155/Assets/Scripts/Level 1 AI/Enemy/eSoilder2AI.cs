using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSoilder2AI : MonoBehaviour {
    private static string defence = "eSoilder2";
    private bool alive = true;
    public int health = 3; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnMouseDown()
    {
        print("clicked");
        GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
    }

    public bool DamageTaken()
    {
        health = health - 1; 
        print("eSoilder2 Damaged");
        if (health == 0)
        {
            alive = false;
        }
        return alive;
    }

}
