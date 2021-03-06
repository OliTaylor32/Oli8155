﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1b : MonoBehaviour {

    public static Transform target;
    public float smoothing = 5.0f;
    
	// Use this for initialization
	void Start () {
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer.Prepare();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        if (Input.GetKey("escape"))
        {
            Application.LoadLevel("Stage1Failed");
        }
    }

    private void Follow(string newTarget)
    {
        GameObject nextTarget = GameObject.Find(newTarget);
        target = nextTarget.transform;
    }

    private void pGunnerVeSoilder2()
    {
        print("Cutscene Initiate.");
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }
}

