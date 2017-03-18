using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class MoveCamera : MonoBehaviour {

    public float dragSpeed = 2;
    public double CameraResetTime = 2.5;
    private Vector3 dragOrigin;
    private double timeLeft = 0;
    private AutoCam autoCam;

    void Start() {
        autoCam = gameObject.GetComponent<AutoCam>();
    }


    void Update() {
        putCameraBackInTime();
        if (Input.GetMouseButtonDown(1)) {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) {
            return;
        }
        autoCam.m_TurnSpeed = 0;
        timeLeft = CameraResetTime;
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.y * dragSpeed, pos.x * dragSpeed,0);

        transform.Rotate(move);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);       //Makes sure our Z rotation is always 0.
        putCameraBackInTime();
    }

    /// <summary>
    /// Puts the camera back behind the boat after timeleft has elapsed.
    /// </summary>
    private void putCameraBackInTime() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            autoCam.m_TurnSpeed = 2;
        }
    }
}
