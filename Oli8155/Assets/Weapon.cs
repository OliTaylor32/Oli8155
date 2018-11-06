using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool canFire = true; 

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        if (canFire = true)
        {
            isFiring = true;
            Instantiate(BulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            if(GetComponent<AudioSource>() !=null)
            {
               GetComponent<AudioSource>().Play();
            }

        
        }
        canFire = false;
       
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
	}
}
