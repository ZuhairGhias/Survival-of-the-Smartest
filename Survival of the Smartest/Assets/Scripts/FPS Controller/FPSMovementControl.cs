using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovementControl : MonoBehaviour {

    CharacterController characterController;
    public float walkSpeed = 3f;
    public float strideLength = 1.5f;

    // footstep sounds
    public AudioSource footstepSource;
    public AudioClip[] footstepSounds;

    private Vector3 lastPosition;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        lastPosition = transform.position;
    }

    void Update()
    {
        MovePlayer();

        // play footstep sound
        if (characterController.isGrounded == true && 
            GetComponent<AudioSource>().isPlaying == false &&
            (Vector3.Distance(transform.position, lastPosition) > strideLength))
        {
            // select a random footstep sound and play it
            footstepSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepSource.pitch = Random.Range(0.9f, 1.1f);
            footstepSource.Play();

            // set the last transform position
            lastPosition = transform.position;
        }
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
