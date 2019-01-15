using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pGunnerMove : MonoBehaviour {

    public float speed = 5.0f;
    public float stamina = 10.0f;
    Rigidbody2D rigidbody2D;
    public float distanceTravelled = 0;
    Vector3 startingPosition;
    private float x;
    private float y;
    private bool canMove = false;
    private bool selected = false;
    public bool alive = true;
    public int health = 10;
    public bool sandBag = false;
    public Slider PlayerHealth;
    public Slider PlayerStamina;
    
    // Use this for initialization
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private static void Movement(Rigidbody2D rigidbody2D, float x, float y, float speed)
    {
        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;
    }
    // Update is called once per frame
    void Update() {

        distanceTravelled = Vector3.Distance(startingPosition, transform.position);

        if (distanceTravelled > stamina)
        {
            canMove = false;
        }

        if (canMove == true)
        {

            float x = Input.GetAxis("Horizontal") * 0.25f;
            float y = Input.GetAxis("Vertical") * 0.25f;
            Movement(rigidbody2D, x, y, speed);
        }

        if (canMove == false)
        {
            x = 0;
            y = 0;
        }

        PlayerHealth.value = health;
        PlayerStamina.value = distanceTravelled;


    }

    private void MyTurn()
    {
        if (alive == true)
        {
            selected = true;
            canMove = true;
            startingPosition = transform.position;
        }
    }

    private void OnMouseDown()
    {
        if (selected == true)
        {
            print("Player Passive End Turn");
            selected = false;
            canMove = false;
            GameObject.Find("TurnMaster").SendMessage("PGunnerDone", SendMessageOptions.DontRequireReceiver);
        }

    }

    public int DamageTaken(int power)
    {
        if (sandBag == false)
            health = health - power;
        else
            health = health - (power / 2);

        if (health <= 0)
        {
            Application.LoadLevel("Stage1Failed");
        }
        return health;
    }

    public void SandBagEnter()
    {
        sandBag = true;
    }

    public void SandBagExit()
    {
        sandBag = false;
    }

    public void Attacking()
    {
        canMove = false;
    }

}
