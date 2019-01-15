using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer.Prepare();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }
}
