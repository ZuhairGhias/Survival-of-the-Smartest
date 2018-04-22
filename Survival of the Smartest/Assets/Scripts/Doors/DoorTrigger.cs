using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public DoubleDoorBehavior door; // door to work with
    public bool openDoor = false; // indicates whether to open the door upon entering trigger (true opens, false closes)

    private void OnTriggerEnter(Collider other)
    {
        // if the collider is the player object, handle behavior
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            if (openDoor)
            {
                door.OpenDoors();
            } else
            {
                // disable the door
                door.CloseDoors();
                door.doorEnabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if the collider is the player object, handle behavior
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            if (openDoor)
            {
                door.CloseDoors();
            }
        }
    }
}
