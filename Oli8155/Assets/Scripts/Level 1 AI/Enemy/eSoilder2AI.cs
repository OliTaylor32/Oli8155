﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eSoilder2AI : MonoBehaviour {
    private static string defence = "eSoilder2";
    private bool alive = true;
    public int health = 4;
    protected Animator animator;
    // Use this for initialization
    void Start () {
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer.Prepare();
    }

    // Update is called once per frame
     void Update() {

	}
    
    private void OnMouseDown()
    {
        print("clicked");
        GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
    }

    public bool DamageTaken(int power)
    {
        health = health - (power/2); 
        print("eSoilder2 Damaged");
        if (health == 0)
        {
            print("Health = 0");
            alive = false;
            print("Defeated Anim playing");
            animator = GetComponent<Animator>();
            animator.Play("Defeated");

        }

        return alive;
    }

    private IEnumerator MyTurn()
    {
        yield return new WaitForSecondsRealtime(10);
        if (alive == true)
        {
            print("eSoilder2 Attacks pGunner");
            defence = "pGunner";
            GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
            defence = "eSoilder2";
            var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.Play();
            videoPlayer.loopPointReached += EndReached;
        }
        else
        {
            yield return new WaitForSecondsRealtime(2);
            GameObject.Find("TurnMaster").SendMessage("ESoldier2Done", SendMessageOptions.DontRequireReceiver);
        }

    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        GameObject.Find("TurnMaster").SendMessage("ESoldier2Done", SendMessageOptions.DontRequireReceiver);
    }
    

}
