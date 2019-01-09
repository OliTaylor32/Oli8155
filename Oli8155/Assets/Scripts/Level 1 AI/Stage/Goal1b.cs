using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal1b : MonoBehaviour {
    public int defeated = 0;
    private double time = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
    }

    void OnTriggerEnter2D()
    {
        if (defeated == 4)
        {
            ResultStore.objective1 = true;
            print("All Soldiers defeated");
        }
        else
        {
            ResultStore.objective1 = false;
        }

        if (time < 240)
        {
            ResultStore.objective2 = true;
            print("Below 4 mins");
        }
        else
        {
            ResultStore.objective2 = false;
        }

        print("Goal Reached");
        Application.LoadLevel("Stage1Complete");
    }

    private void Defeated()
    {
        defeated += 1;
    }

}
