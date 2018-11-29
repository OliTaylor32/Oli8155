using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSoldier1AI : MonoBehaviour {
    private static string defence = "pSoilder1";
    private bool alive = true;
    public int health = 2;
    protected Animator animator;
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
        alive = false;
        return alive;
    }

    private IEnumerator MyTurn()
    {
        animator = GetComponent<Animator>();
        yield return new WaitForSecondsRealtime(2);
        animator.Play("pSoldier1");
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

}
