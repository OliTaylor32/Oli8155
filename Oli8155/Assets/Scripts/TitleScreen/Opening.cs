using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Application.LoadLevel("Stage1");
        Destroy(vp);
    }
}
