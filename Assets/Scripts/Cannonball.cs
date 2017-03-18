using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        Vector3 movement = transform.rotation * new Vector3(1000, 150, 0);
        rigid.AddForce(movement);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
