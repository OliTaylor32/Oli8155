using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pSoldier1AI : MonoBehaviour {
    private static string defence = "pSoilder1";
    private bool alive = true;
    public int health = 2;
    protected Animator animator;
    public Slider OtherHealth;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.StopPlayback();
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public bool DamageTaken()
    { 
        print("pSoilder1 Damaged");
        health = 0;
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
            animator.Play("pSoldier1");
            //Attack Animation
            print("pSoldier1 Attacks eSoldier2");
            yield return new WaitForSecondsRealtime(10);
            GameObject.Find("eSoilder2").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
            GameObject.Find("TurnMaster").SendMessage("PSoldier1Done", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            GameObject.Find("TurnMaster").SendMessage("PSoldier1Done", SendMessageOptions.DontRequireReceiver);
        }
        
        //print("pSoldier1 Attacks eSoldier2");
        //defence = "eSoldier2";
        //GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
        //defence = "pSoldier1";
        ////var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        ////videoPlayer.Play();
        ////videoPlayer.loopPointReached += EndReached;


    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        GameObject.Find("TurnMaster").SendMessage("PSoilder1Done", SendMessageOptions.DontRequireReceiver);
    }

    private void OnMouseOver()
    {
        OtherHealth.value = health;
        OtherHealth.maxValue = 2;
    }
    private void OnMouseExit()
    {
        OtherHealth.value = 0;
    }

}
