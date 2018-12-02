﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaster1b : MonoBehaviour {
    public string attack;
    public string newTarget;
    public bool canAttack = true;
    public int power = 1;
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
        GameObject.Find("pSoldier1").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "pSoldier1";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;

    }
    private string PSoldier1Done()
    {
        GameObject.Find("eSoldier3").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eSoldier3";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;

    }
    private string ESoldier3Done()
    {
        GameObject.Find("eSoldier4").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eSoldier4";
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
                    power = 2; 
                    switch (defence)
                    {
                        case "eSoilder2":
                            GameObject.Find("Main Camera").SendMessage("pGunnerVeSoilder2", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("pSniper v eSoilder2");
                            GameObject.Find("eSoilder2").SendMessage("DamageTaken", power, SendMessageOptions.DontRequireReceiver);
                            break;
                    }


                break;

                case "eSoilder2":
                    power = 2;
                    GameObject.Find("pGunner").SendMessage("DamageTaken", power, SendMessageOptions.DontRequireReceiver);
                    break;
            }
            canAttack = false;
        }
        return canAttack;
       
    }
}
