using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScare : MonoBehaviour {
    
    public AudioSource knockingSound;
    public Collider trigger1;
    public Transform spawnLocation;
    public GameObject edwardo;
    public AudioClip scareSound;

    private bool scareEnabled = false;
    private Camera mainCam;

    void Start() {
        mainCam = Camera.main;
    }

    void Update() {
        if (scareEnabled == true) {
            Vector3 screenPosition = mainCam.WorldToViewportPoint(edwardo.transform.position);

            if (screenPosition.x > 0 && screenPosition.x < 1 && screenPosition.y > 0 && screenPosition.y < 1 && screenPosition.z > 0) {
                
                StartCoroutine(EndScare());
            }
        }
    }

    private IEnumerator EndScare()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().clip = scareSound;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    public void Trigger1() {
        trigger1.gameObject.SetActive(false);
        knockingSound.Play();
        edwardo = Instantiate(edwardo, spawnLocation.position, spawnLocation.rotation, this.transform);
        scareEnabled = true;
    }

}
