using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject cannonball;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            FireCannon();
            Debug.Log("Pressed left click.");
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
