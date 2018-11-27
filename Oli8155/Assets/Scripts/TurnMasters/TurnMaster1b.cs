using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaster1b : MonoBehaviour {
    public string attack;
    public string newTarget;
    public bool canAttack = true;
    // Use this for initialization
    string Start () {
        GameObject.Find("pGunner").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "pGunner";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        return newTarget;
	}
	
	// Update is called once per frame
	string Update () {
        attack = newTarget;
        return attack;
	}

    private string PGunnerDone()
    {
        GameObject.Find("eSoilder2").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eSoilder2";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;
        
    }
    private string ESoldier2Done()
    {
        GameObject.Find("eSoilder2").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eSoilder2";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;

    }

    public bool Battle(string defence)
    {
        if (canAttack == true)
        {
            switch (attack)
            {
                 case "pGunner":
                    PGunnerDone();
                    switch (defence)
                    {
                        case "eSoilder2":
                            GameObject.Find("Main Camera").SendMessage("pGunnerVeSoilder2", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("pSniper v eSoilder2");
                            GameObject.Find("eSoilder2").SendMessage("DamageTaken");
                            break;
                    }


                break;
            }
            canAttack = false;
        }
        return canAttack;
       
    }
}
