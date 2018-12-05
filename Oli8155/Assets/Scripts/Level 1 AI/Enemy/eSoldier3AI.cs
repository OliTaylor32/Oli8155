using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSoldier3AI : MonoBehaviour {
    private static string defence = "eSoldier3";
    private bool alive = true;
    public int health = 2;
    protected Animator animator;
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
        if (alive == false)
        {
           
        }
	}

    public bool DamageTaken()
    { 
        print("eSoilder3 Damaged");
        alive = false;
        animator = GetComponent<Animator>();
        animator.Play("Defeated");
        return alive;
    }

    private IEnumerator MyTurn()
    {
        if (alive == true)
        {
            animator = GetComponent<Animator>();
            yield return new WaitForSecondsRealtime(2);
            animator.Play("eSoldier3");
            //Attack animation
            print("eSoldier3 Attacks pSoldier1");
            yield return new WaitForSecondsRealtime(8);
            GameObject.Find("pSoldier1").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
            GameObject.Find("TurnMaster").SendMessage("ESoldier3Done", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            yield return new WaitForSecondsRealtime(2);
            GameObject.Find("TurnMaster").SendMessage("ESoldier3Done", SendMessageOptions.DontRequireReceiver);
        }
        //print("pSoldier1 Attacks eSoldier2");
        //defence = "eSoldier2";
        //GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
        //defence = "pSoldier1";
        ////var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        ////videoPlayer.Play();
        ////videoPlayer.loopPointReached += EndReached;


    }

    //private void EndReached(UnityEngine.Video.VideoPlayer vp)
    //{
    //    vp.Stop();
    //    GameObject.Find("TurnMaster").SendMessage("PSoilder1Done", SendMessageOptions.DontRequireReceiver);
    //}

}
