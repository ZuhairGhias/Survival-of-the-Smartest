using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScareTrigger1 : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            GetComponentInParent<DoorScare>().Trigger1();
        }
    }

}
