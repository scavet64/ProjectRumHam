using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    Rigidbody rigid;
    Buoyancy buoyance;

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
        buoyance = gameObject.GetComponent<Buoyancy>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.GetComponent<Cannonball>() != null) {
            Sink();
        }
    }

    private void Sink() {
        rigid.AddTorque(transform.right * -500);
        rigid.AddForce(new Vector3(0, 1000, 0));
        Destroy(gameObject.GetComponent<Buoyancy>());
        Destroy(gameObject, 2);
    }
}
