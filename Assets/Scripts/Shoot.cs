using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shoot : MonoBehaviour
{

    public GameObject cannonball;
    private NetworkIdentity test;

    // Use this for initialization
    void Start () {
        test = GetComponentInParent<NetworkIdentity>();

    }
	
	// Update is called once per frame
	void Update () {

            if (Input.GetMouseButtonDown(0))
            {
            if (test.isLocalPlayer)
            {
                FireCannon();
                Debug.Log("Pressed left click.");
            }
            }
    }

    /// <summary>
    /// Fire the cannon
    /// </summary>
    public void FireCannon()
    {
        GameObject tmp = Instantiate(cannonball, this.transform.position, this.transform.rotation);
        tmp.transform.Rotate(Vector3.up, -90);
        Destroy(tmp, 1);
    }
}
