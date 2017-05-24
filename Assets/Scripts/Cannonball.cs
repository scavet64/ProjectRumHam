using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();

        float randomXForce = Random.Range(1000, 1500);
        float randomYForce = Random.Range(100, 200);

        Vector3 movement = transform.rotation * new Vector3(randomXForce, randomYForce, 0);
        rigid.AddForce(movement);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
