using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {

    public Transform door;

    private bool isOpen = false;
    public float openRate = 1;
    public AudioSource doorSound;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    // Use this for initialization
    void Start () {
        openRotation = Quaternion.Euler(0, -90, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpen) {
            door.localRotation = Quaternion.Lerp(door.rotation, openRotation, Time.deltaTime*openRate);
            
        }
	}

    public void Open() {
        if (!isOpen) {

            doorSound.Play();
        }
        this.isOpen = true;
    }
}
