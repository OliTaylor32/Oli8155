using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBags : MonoBehaviour {

    public GameObject character;



    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.name == "AreaChecker")
        {
            print("SandBag enter");
            character.SendMessage("SandBagEnter", SendMessageOptions.DontRequireReceiver);
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == name)
        {
            character.SendMessage("SandBagExit", SendMessageOptions.DontRequireReceiver);
        }

    }
}
