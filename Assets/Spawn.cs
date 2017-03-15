using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        GameObject bla = new GameObject();

        Instantiate(player, new Vector3(0, 20, 0), Quaternion.identity).transform.SetParent(bla.transform);
        Instantiate(player, new Vector3(10, 20, 0), Quaternion.identity).transform.SetParent(bla.transform);
        Instantiate(player, new Vector3(20, 20, 0), Quaternion.identity).transform.SetParent(bla.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnStuff() {
        Instantiate(player, new Vector3(0, 10, 0), Quaternion.identity);
    }
}
