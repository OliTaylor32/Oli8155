using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    public static Transform target;
    public float smoothing = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
	}

    private void Follow(string newTarget)
    {
        GameObject nextTarget = GameObject.Find(newTarget);
        target = nextTarget.transform;
    }
}
