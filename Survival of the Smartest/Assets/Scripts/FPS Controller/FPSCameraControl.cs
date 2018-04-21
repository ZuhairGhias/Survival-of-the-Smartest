using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraControl : MonoBehaviour {

    public Transform playerBody;
    public float mouseSensitivity;

    float xAxisClamp = 0.0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        // x and y-axis changes
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // speed of rotation
        float rotationAmountX = mouseX * mouseSensitivity;
        float rotationAmountY = mouseY * mouseSensitivity;

        // x-axis clamp
        xAxisClamp -= rotationAmountY;

        // current rotation of the game object
        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        // rotate by the rotation amount
        targetRotCam.x -= rotationAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotationAmountX;

        // handle value clamping for up/down looking
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        // set the transformation
        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
    }
}
