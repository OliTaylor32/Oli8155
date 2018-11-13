using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaster1 : MonoBehaviour {
    public string attack;
    public string newTarget;
    public bool canAttack = true;
    // Use this for initialization
    string Start () {
        GameObject.Find("pSniper").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "pSniper";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        return newTarget;
	}
	
	// Update is called once per frame
	string Update () {
        attack = newTarget;
        return attack;
	}

    private string PSniperDone()
    {
        GameObject.Find("eSoilder1").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eSoilder1";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        return newTarget;
    }

    public bool Battle(string defence)
    {
        if (canAttack == true)
        {
            switch (attack)
            {
                 case "pSniper": 
                    switch (defence)
                    {
                        case "eSoilder1":
                            //Play Animation
                            //Take away health
                            Debug.Log("pSniper v eSoilder1");
                            GameObject.Find("eSoilder1").SendMessage("DamageTaken");
                            break;
                     }


                break;
            }
            canAttack = false;
        }
        return canAttack;
       
    }
}
