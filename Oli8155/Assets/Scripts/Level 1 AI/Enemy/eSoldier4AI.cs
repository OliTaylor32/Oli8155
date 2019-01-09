using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eSoldier4AI : MonoBehaviour {
    private static string defence = "eSoldier4";
    private bool alive = true;
    public int health = 4;
    public GameObject target;
    protected Animator animator;
    public Slider OtherHealth;

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
        if (health <= 0)
        {
            alive = false;
            animator = GetComponent<Animator>();
            animator.Play("Defeated");
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            GameObject.Find("Goal Collision").SendMessage("Defeated", SendMessageOptions.DontRequireReceiver);
        }
        return alive;
    }

    private IEnumerator MyTurn()
    {
        yield return new WaitForSecondsRealtime(2);
        if (alive == true)
        
        {
            GameObject target = GameObject.Find("pGunner");
            if (Vector3.Distance(target.transform.position, this.transform.position) <= 4)
            {
                print("eSoldier4 Attacks pGunner1 ");
                var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
                videoPlayer.Play();
                videoPlayer.loopPointReached += EndReached;
            }
            else
            {
                GameObject.Find("TurnMaster").SendMessage("ESoldier4Done", SendMessageOptions.DontRequireReceiver);
            }
            

        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            GameObject.Find("TurnMaster").SendMessage("ESoldier4Done", SendMessageOptions.DontRequireReceiver);
        }

    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GameObject.Find("pGunner").SendMessage("DamageTaken", 2, SendMessageOptions.DontRequireReceiver);
        vp.Stop();
        GameObject.Find("TurnMaster").SendMessage("ESoldier4Done", SendMessageOptions.DontRequireReceiver);
    }
    private void OnMouseOver()
    {
        OtherHealth.value = health;
        OtherHealth.maxValue = 4;
    }

    private void OnMouseExit()
    {
        OtherHealth.value = 0;
    }


}
