using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorBehavior : MonoBehaviour {

    public GameObject leftDoorPivot;
    public GameObject rightDoorPivot;

    // current desired rotations of both doors
    private Quaternion leftDoorRotation;
    private Quaternion rightDoorRotation;

    // door opening speed
    public float speed = 100f;
    public bool doorOpen;

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
        leftDoorRotation = Quaternion.Euler(0f, -75f, 0f);

        // right door open rotation
        rightDoorRotation = Quaternion.Euler(0f, 75f, 0f);

        doorOpen = true;
    }

    public void Update()
    {
        float step = speed * Time.deltaTime;

        // continuously rotate both doors to their desired rotations
        leftDoorPivot.transform.rotation = Quaternion.RotateTowards(leftDoorPivot.transform.rotation, leftDoorRotation, step);
        rightDoorPivot.transform.rotation = Quaternion.RotateTowards(rightDoorPivot.transform.rotation, rightDoorRotation, step);

        // debug for easier door opening
        if (Input.GetKeyDown(KeyCode.Space))
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
