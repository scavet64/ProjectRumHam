using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealtimeShipControl : MonoBehaviour {
    const int MAX_SPEED = 60;
    const int SPEED_ADJUST = 20;
    const float ROTATION_ADJUST_SPEED = 0.3F;
    
    Rigidbody rigid;
    int speed;
    public GameObject cannonball;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Adjust direction of y-rotation
        if (speed != 0) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - (ROTATION_ADJUST_SPEED + (MAX_SPEED - speed) / MAX_SPEED));
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + (ROTATION_ADJUST_SPEED + (MAX_SPEED - speed) / MAX_SPEED));
            }
        }

        // Adjust speed
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (speed < MAX_SPEED) {
                speed += SPEED_ADJUST;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (speed > 0) {
                speed -= SPEED_ADJUST;
            }
        }

        Vector3 movement = transform.rotation * new Vector3(0, 0, speed);
        if (rigid.velocity.magnitude < SPEED_ADJUST) {
            rigid.AddForce(movement);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            FireCannonballs();
        }
	}

    private void FireCannonballs() {
        for (int i = 1; i < 8; i++) {
            Destroy(Instantiate(cannonball, GameObject.Find("cannon" + i).transform.position, GameObject.Find("cannon" + i).transform.rotation), 1);
        }
    }
}
