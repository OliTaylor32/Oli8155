using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSoldier2AI : MonoBehaviour {
    private static string defence = "pSoilder2";
    private bool alive = true;
    public int health = 2;
    protected Animator animator;
    public int turn = 1; 
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.StopPlayback();
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        //videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public bool DamageTaken()
    { 
        print("pSoilder2 Damaged");
        health = 0;
        alive = false;
        return alive;
    }

    private IEnumerator MyTurn()
    {
        if (alive == true)
        {
            if (turn == 1)
            {
                animator = GetComponent<Animator>();
                yield return new WaitForSecondsRealtime(2);
                animator.Play("pSoldier2(1)");
                //Attack Animation
                print("pSoldier2 Attacks eSoldier2");
                yield return new WaitForSecondsRealtime(10);
                GameObject.Find("eSoilder2").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
                GameObject.Find("TurnMaster").SendMessage("PSoldier2Done", SendMessageOptions.DontRequireReceiver);
                
            }
            else if (turn == 2)
            {
                animator = GetComponent<Animator>();
                yield return new WaitForSecondsRealtime(2);
                animator.Play("pSoldier2(2)");
                //Attack Animation
                print("pSoldier2 Attacks eGunner");
                yield return new WaitForSecondsRealtime(12);
                GameObject.Find("eGunner1").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
                GameObject.Find("TurnMaster").SendMessage("PSoldier2Done", SendMessageOptions.DontRequireReceiver);
            }
            else if (turn >= 3)
            {
                //Attack Animation
                print("pSoldier2 Attacks eGunner");
                yield return new WaitForSecondsRealtime(4);
                GameObject.Find("eGunner1").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
                GameObject.Find("TurnMaster").SendMessage("PSoldier2Done", SendMessageOptions.DontRequireReceiver);
            }
            turn = turn + 1;
        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            GameObject.Find("TurnMaster").SendMessage("PSoldier2Done", SendMessageOptions.DontRequireReceiver);
        }


    }
}
