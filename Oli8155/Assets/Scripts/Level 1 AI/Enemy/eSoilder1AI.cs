using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSoilder1AI : MonoBehaviour {
    private static string defence = "eSoilder1";
    private bool alive = true;
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
        print("eSoilder1 Killed");
        alive = false;
        return alive;
    }

}
