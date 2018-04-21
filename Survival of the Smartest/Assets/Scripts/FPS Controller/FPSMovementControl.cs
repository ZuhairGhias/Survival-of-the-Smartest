using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovementControl : MonoBehaviour {

    CharacterController characterController;
    public float walkSpeed;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // get axis input on horizontal and vertical axes
        float horizontalAmount = Input.GetAxis("Horizontal");
        float verticalAmount = Input.GetAxis("Vertical");

        // set the movement vectors for each direction
        Vector3 moveDirSide = transform.right * horizontalAmount * walkSpeed;
        Vector3 moveDirForward = transform.forward * verticalAmount * walkSpeed;

        characterController.SimpleMove(moveDirSide);
        characterController.SimpleMove(moveDirForward);

    }
}
