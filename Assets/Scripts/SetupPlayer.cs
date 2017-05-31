using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;

public class SetupPlayer : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
        //GetComponentInChildren<AutoCam>().SetTarget();
        if(isLocalPlayer)
            GetComponentInChildren<Camera>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
