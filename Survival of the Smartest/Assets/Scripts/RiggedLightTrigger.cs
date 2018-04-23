using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggedLightTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            print("Trigger");
            GetComponentInParent<LightScare>().Trigger();
            Destroy(this.gameObject);
        }
        
    }

}
