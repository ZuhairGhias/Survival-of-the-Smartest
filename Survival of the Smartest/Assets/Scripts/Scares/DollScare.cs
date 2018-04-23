using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollScare : MonoBehaviour {

    public GameObject dollPrefab;
    public Transform[] spawnLocations;
    public AudioSource demonGirlSound;
    private bool scareEnabled = false;


    public void Trigger() {
        demonGirlSound.Play();
        //Transform spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
        //Instantiate(dollPrefab, spawnLocation.position, spawnLocation.rotation, this.GetComponentInParent<Hallway>().transform);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player" && scareEnabled == false) {
            Trigger();
        }
        
    }
}
