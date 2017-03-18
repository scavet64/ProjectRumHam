using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    const int MAX_SPEED = 30;
    const int SPEED_ADJUST = 10;
    const float MAX_ROTATION_SPEED = 0.15F;
    const float ROTATION_ADJUST_SPEED = 5F;

    Rigidbody rigid;
    int speed;
    public GameObject cannonball;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            FireCannonballs("portside");
        }

        // Adjust direction of y-rotation
        if (speed != 0) {
            if (Input.GetKey(KeyCode.LeftArrow) && rigid.angularVelocity.magnitude < MAX_ROTATION_SPEED) {
                rigid.AddTorque(transform.up * -ROTATION_ADJUST_SPEED);
            }
            if (Input.GetKey(KeyCode.RightArrow) && rigid.angularVelocity.magnitude < MAX_ROTATION_SPEED) {
                rigid.AddTorque(transform.up * ROTATION_ADJUST_SPEED);
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


    }

    public void FireCannonballs(string side) {
        float timer = Time.time + 2;
        int i = 1;
        while (i < 8) {
            FireCannon(side, i);
            i++;
        }
    }

    public void FireCannon(string side, int cannonNum) {
        Destroy(Instantiate(cannonball, GameObject.Find(side + cannonNum).transform.position, GameObject.Find(side + cannonNum).transform.rotation), 1);
    }
}
