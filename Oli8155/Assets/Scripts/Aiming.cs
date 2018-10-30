using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    public float speed = 5.0f;
    public float Range = 10.0f;
    Rigidbody2D rigidbody2D;
    public bool selected = false;
    public float distanceTravelled = 0;
    Vector3 startingPosition;
    private float x;
    private float y;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        distanceTravelled = Vector3.Distance(startingPosition, transform.position);

        if (distanceTravelled > stamina)
        {
            selected = false;

        }

        if (selected == true)
        {
            float x = Input.GetAxis("Horizontal") * 0.25f;
            float y = Input.GetAxis("Vertical") * 0.25f;
            Movement(rigidbody2D, x, y, speed);
        }

        if (selected == false)
        {
            x = 0;
            y = 0;
        }

    }
}
