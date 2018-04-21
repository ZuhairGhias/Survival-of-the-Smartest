using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera mainCam;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPosition = transform.position + (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * moveSpeed/10;
        //GetComponent<Rigidbody>().MovePosition(newPosition);

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.position = newPosition;
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        mainCam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);



    }
}
