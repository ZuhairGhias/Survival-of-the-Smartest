using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellScare : MonoBehaviour {

    public AudioSource bell;

    void OnTriggerEnter(Collider other)
    {
        print("BELL TRIGGERED");
        bell.Play();
        Destroy(this.gameObject);
    }
}
