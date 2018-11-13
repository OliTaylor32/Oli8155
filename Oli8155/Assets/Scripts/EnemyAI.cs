using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSoilder1 : MonoBehaviour {
    public static string obj = "eSoilder1"; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private static void Attacked(int damage)
    {
       GameObject.Find("TurnMaster").SendMessage("Battle", obj, SendMessageOptions.DontRequireReceiver);
    }
}
