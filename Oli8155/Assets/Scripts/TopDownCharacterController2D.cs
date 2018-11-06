using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 5.0f;
    public float stamina = 10.0f;
    Rigidbody2D  rigidbody2D;
    public float distanceTravelled = 0;
    Vector3 startingPosition;
    private float x;
    private float y;
    private bool selected = false;
    public string canAttack = "no";
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
}
	
    private static void Movement(Rigidbody2D rigidbody2D, float x, float y, float speed)
    {
        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;
    }
	// Update is called once per frame
	void Update () {

        distanceTravelled = Vector3.Distance(startingPosition, transform.position);

        if (distanceTravelled > stamina)
        {
            selected = false;
            GameObject.Find("TurnMaster").SendMessage("PSniperDone", SendMessageOptions.DontRequireReceiver); 
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

    private void MyTurn()
    {
        selected = true;
        canAttack = "yes";
    }
}
