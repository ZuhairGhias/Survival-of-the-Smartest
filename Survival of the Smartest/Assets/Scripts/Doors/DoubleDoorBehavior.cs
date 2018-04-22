using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorBehavior : MonoBehaviour {

    public GameObject leftDoorPivot;
    public GameObject rightDoorPivot;

    // current desired rotations of both doors
    private Quaternion leftDoorRotation;
    private Quaternion rightDoorRotation;

    public float speed = 100f; // door opening speed
    public float openDegrees = 75f; // how many degrees the door should open to (negative values open the other way)
    public bool doorOpen = false; // whether the door is currently open

    public bool debugMode = false; // if debug is enabled, then pressing SPACE toggles the doors

    void Start()
    {
        leftDoorRotation = new Quaternion();
        rightDoorRotation = new Quaternion();

        CloseDoors();
    }

    public void CloseDoors()
    {
        // left door closed rotation
        leftDoorRotation = Quaternion.Euler(0f, 0f, 0f);

        // right door closed rotation
        rightDoorRotation = Quaternion.Euler(0f, 0f, 0f);

        doorOpen = false;
    }

    public void OpenDoors()
    {
        // left door open rotation
        leftDoorRotation = Quaternion.Euler(0f, -openDegrees, 0f);

        // right door open rotation
        rightDoorRotation = Quaternion.Euler(0f, openDegrees, 0f);

        doorOpen = true;
    }

    public void Update()
    {
        float step = speed * Time.deltaTime;

        // continuously rotate both doors to their desired rotations
        leftDoorPivot.transform.rotation = Quaternion.RotateTowards(leftDoorPivot.transform.rotation, leftDoorRotation, step);
        rightDoorPivot.transform.rotation = Quaternion.RotateTowards(rightDoorPivot.transform.rotation, rightDoorRotation, step);

        // debug for easier door opening
        if (Input.GetKeyDown(KeyCode.Space) && debugMode)
        {
            if (doorOpen)
            {
                CloseDoors();
            } else
            {
                OpenDoors();
            }
        }
    }
}
