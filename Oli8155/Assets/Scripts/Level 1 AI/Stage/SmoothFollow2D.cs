using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    public static Transform target;
    public float smoothing = 5.0f;
    
	// Use this for initialization
	void Start () {
        //Setting up the the battle animation
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer.Prepare();
    }
	
	// Update is called once per frame
	void Update () {
        //Finding the object to follow and moving towards the target.
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        //When the escape key is pressed, load the main menu
        if (Input.GetKey("escape"))
        {
            Application.LoadLevel("Main Menu");
        }

    }

    private void Follow(string newTarget)
    {
        //Adjusting the camera to follow a new target.
        GameObject nextTarget = GameObject.Find(newTarget);
        target = nextTarget.transform;
    }

    private void pSniperVeSoilder1()
    {
        //Play the battle animation
        print("Cutscene Initiate.");
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;
    }

    //When the video ends, load the next part of the level.
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Application.LoadLevel("Stage1b");
        Destroy(vp);
    }
}

