using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    public int damage = 1;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("Attacked", damage, SendMessageOptions.DontRequireReceiver);
        Die();
    }

    private void OnBecomeInvisible()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
