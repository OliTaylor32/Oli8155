using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaster1 : MonoBehaviour {
 
    // Use this for initialization
    void Start () {
        GameObject.Find("pSniper").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        string newTarget = "pSniper";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PSniperDone()
    {
        GameObject.Find("eSoilder1").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        string newTarget = "eSoilder1";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
    }
}
