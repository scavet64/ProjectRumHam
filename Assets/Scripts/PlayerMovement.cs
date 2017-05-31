using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    const int MAX_SPEED = 50;
    const int SPEED_ADJUST = 10;
    const float MAX_ROTATION_SPEED = 0.50F;
    const float ROTATION_ADJUST_SPEED = 0.5F;
    private readonly int[] CannonArray = { 1, 2, 3, 4, 5, 6, 7 };
    private readonly System.Random rnd = new System.Random();
    private bool nolimits = true;

    Rigidbody rigid;
    int speed;
    public GameObject cannonball;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        if (isLocalPlayer)
        {
            // Adjust direction of y-rotation
            if (speed >= MAX_ROTATION_SPEED || nolimits)
            {
                if (Input.GetKey(KeyCode.LeftArrow) && rigid.angularVelocity.magnitude < MAX_ROTATION_SPEED)
                {
                    rigid.AddTorque(transform.up * -ROTATION_ADJUST_SPEED);
                    Debug.Log("Speed left:");
                }
                if (Input.GetKey(KeyCode.RightArrow) && rigid.angularVelocity.magnitude < MAX_ROTATION_SPEED)
                {
                    rigid.AddTorque(transform.up * ROTATION_ADJUST_SPEED);
                    Debug.Log("Speed right:");
                }
            }

            // Adjust speed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (speed < MAX_SPEED)
                {
                    speed += SPEED_ADJUST;
                    Debug.Log("Speed Adjusted: " + speed);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (speed > 0)
                {
                    speed -= SPEED_ADJUST;
                    Debug.Log("Speed Adjusted: " + speed);
                }
            }

            Vector3 movement = transform.rotation * new Vector3(0, 0, speed);
            if (rigid.velocity.magnitude < SPEED_ADJUST)
            {
                rigid.AddForce(movement);
            }
        }

    }

    public void FireCannonballs(string side) {
        float timer = Time.time + 2;
        int[] MyRandomArray = CannonArray.OrderBy(x => rnd.Next()).ToArray();

        IEnumerator coroutine = StaggerRandomLaunchCannons(side, MyRandomArray);
        StartCoroutine(coroutine);
    }

    private IEnumerator StaggerRandomLaunchCannons(string side, int[] randomCannonArray) {
        for (int i = 0; i < randomCannonArray.Length; i++) {
            FireCannon(side, randomCannonArray[i]);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void FireCannon(string side, int cannonNum) {
        Destroy(Instantiate(cannonball, GameObject.Find(side + cannonNum).transform.position, GameObject.Find(side + cannonNum).transform.rotation), 1);
    }
}
