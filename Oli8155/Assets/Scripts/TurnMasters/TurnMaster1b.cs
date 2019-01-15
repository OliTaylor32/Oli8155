using System.Collections;
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
        GameObject.Find("eGunner1").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eGunner1";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;

    }

    private string EGunner1Done()
    {
        GameObject.Find("eSoldier4").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "eSoldier4";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;

    }

    private string ESoldier4Done()
    {
        GameObject.Find("pSoldier2").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "pSoldier2";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = false;
        return newTarget;

    }

    private string PSoldier2Done()
    {
        GameObject.Find("pGunner").SendMessage("MyTurn", SendMessageOptions.DontRequireReceiver);
        newTarget = "pGunner";
        GameObject.Find("Main Camera").SendMessage("Follow", newTarget, SendMessageOptions.DontRequireReceiver);
        canAttack = true;
        return newTarget;

    }

    public bool Battle(string defence)
    {
        if (canAttack == true)
        {
            GameObject.Find("pGunner").SendMessage("Attacking", SendMessageOptions.DontRequireReceiver);
            switch (attack)
            {
                 case "pGunner":
                    PGunnerDone();
                    power = 4; 
                    switch (defence)
                    {
                        case "eSoilder2":
                            GameObject.Find("Main Camera").SendMessage("pGunnerVeSoilder2", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("pGunner v eSoilder2");
                            GameObject.Find("eSoilder2").SendMessage("DamageTaken", power, SendMessageOptions.DontRequireReceiver);
                            break;

                        case "eSoldier3":
                            GameObject.Find("AnimeSoldier3").SendMessage("Play", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("pGunner v eSoilder3");
                            GameObject.Find("eSoldier3").SendMessage("DamageTaken", power, SendMessageOptions.DontRequireReceiver);
                            break;

                        case "eSoldier4":
                            GameObject.Find("Main Camera").SendMessage("pGunnerVeSoilder2", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("pGunner v eSoldier4");
                            GameObject.Find("eSoldier4").SendMessage("DamageTaken", power, SendMessageOptions.DontRequireReceiver);
                            break;

                        case "eGunner1":
                            GameObject.Find("Main Camera").SendMessage("pGunnerVeSoilder2", SendMessageOptions.DontRequireReceiver);
                            Debug.Log("pGunner v eGunner1");
                            GameObject.Find("eGunner1").SendMessage("DamageTaken", power, SendMessageOptions.DontRequireReceiver);
                            break;

                    }


                break;

            }
            canAttack = false;
        }
        return canAttack;
       
    }
}
