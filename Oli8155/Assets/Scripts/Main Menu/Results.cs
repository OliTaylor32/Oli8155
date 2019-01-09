using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour {
    public GameObject objective1;
    public Sprite cleared1;
    public Sprite failed1;
    public GameObject objective2;
    public Sprite cleared2;
    public Sprite failed2;
    public GameObject rank;
    public Sprite a;
    public Sprite b;
    public Sprite c;

    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        spriteRenderer = objective1.GetComponent<SpriteRenderer>();
        if (ResultStore.objective1 == true)
        {
            spriteRenderer.sprite = cleared1;
            print("objective1 cleared");
        }
        else
        {
            spriteRenderer.sprite = failed1;
        }

        spriteRenderer = objective2.GetComponent<SpriteRenderer>();
        if (ResultStore.objective2 == true)
        {
            spriteRenderer.sprite = cleared2;
            print("objective 2 cleared.");
        }
        else
        {
            spriteRenderer.sprite = failed2;
        }

        spriteRenderer = rank.GetComponent<SpriteRenderer>();
        if (ResultStore.objective2 == true && ResultStore.objective1 == true)
        {
            spriteRenderer.sprite = a;
        }
        else if (ResultStore.objective2 == true || ResultStore.objective1 == true)
        {
            spriteRenderer.sprite = b;
        }
        else
        {
            spriteRenderer.sprite = c;
        }



    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
