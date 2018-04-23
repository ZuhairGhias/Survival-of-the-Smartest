using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScare : MonoBehaviour {

    private bool scareEnabled = false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player" && !scareEnabled) {
            Locker[] lockers = GetComponent<Collider>().transform.root.GetComponentsInChildren<Locker>();
            print(col.transform.root.name);
            print(lockers.Length);
            lockers[Random.Range(0, lockers.Length)].Open();
            scareEnabled = true;
        }
    }
}
