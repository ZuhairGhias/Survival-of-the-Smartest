using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollScare : MonoBehaviour {

    public AudioSource whisperSound;
    private bool scareEnabled = false;


    public void Trigger() {
        whisperSound.Play();
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player" && scareEnabled == false) {
            Trigger();
        }
        
    }
}
