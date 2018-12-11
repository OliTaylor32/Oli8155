﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eGunner1AI : MonoBehaviour {
    private static string defence = "eGunner1";
    private bool alive = true;
    public int health = 4;
    public GameObject target;
    protected Animator animator;

    // Use this for initialization
    void Start () {
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer.Prepare();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnMouseDown()
    {
        print("clicked");
        GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
    }

    public bool DamageTaken(int power)
    {
        health = health - (power/2); 
        print("eGunner Damaged");
        if (health == 0)
        {
            alive = false;
            animator = GetComponent<Animator>();
            animator.Play("Defeated");
        }
        return alive;
    }

    private IEnumerator MyTurn()
    {
        yield return new WaitForSecondsRealtime(2);
        if (alive == true)
        
        {
            GameObject target = GameObject.Find("pGunner");
            if (Vector3.Distance(target.transform.position, target.transform.position) <= 5)
            {
                print("eGunner1 Attacks pGunner1 ");
                defence = "pGunner";
                GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
                defence = "eGunner1";
                var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
                videoPlayer.Play();
                videoPlayer.loopPointReached += EndReached;
            }

        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            GameObject.Find("TurnMaster").SendMessage("EGunner1Done", SendMessageOptions.DontRequireReceiver);
        }

    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        GameObject.Find("TurnMaster").SendMessage("EGunner1Done", SendMessageOptions.DontRequireReceiver);
    }

}
