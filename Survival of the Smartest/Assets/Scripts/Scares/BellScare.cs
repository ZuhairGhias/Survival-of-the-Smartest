using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellScare : MonoBehaviour {

    public AudioSource bell;

    void OnTriggerEnter(Collider other)
    {
        bell.Play();
        Destroy(this.gameObject);
    }
}
