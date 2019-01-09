using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eSoldier3AI : MonoBehaviour {
    private static string defence = "eSoldier3";
    private bool alive = true;
    public int health = 2;
    private int turn = 1;
    protected Animator animator;
    public Slider OtherHealth;
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

    private void OnMouseDown()
    {
        print("clicked");
        GameObject.Find("TurnMaster").SendMessage("Battle", defence, SendMessageOptions.DontRequireReceiver);
    }

    public bool DamageTaken()
    { 
        print("eSoilder3 Damaged");
        alive = false;
        animator = GetComponent<Animator>();
        animator.Play("Defeated");
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Find("Goal Collision").SendMessage("Defeated", SendMessageOptions.DontRequireReceiver);
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
                animator.Play("eSoldier3");
                //Attack animation
                print("eSoldier3 Attacks pSoldier1");
                yield return new WaitForSecondsRealtime(8);
                GameObject.Find("pSoldier1").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
                GameObject.Find("TurnMaster").SendMessage("ESoldier3Done", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                print("eSoldier3 attacks pGunner");
                var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
                videoPlayer.Play();
                videoPlayer.loopPointReached += EndReached;
            }
            turn = turn + 1;
        }
        else
        {

            yield return new WaitForSecondsRealtime(1);
            GameObject.Find("TurnMaster").SendMessage("ESoldier3Done", SendMessageOptions.DontRequireReceiver);
        }

    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GameObject.Find("pGunner").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
        vp.Stop();
        GameObject.Find("TurnMaster").SendMessage("ESoldier3Done", SendMessageOptions.DontRequireReceiver);
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
