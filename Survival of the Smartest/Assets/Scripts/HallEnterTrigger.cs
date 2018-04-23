using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallEnterTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        print("Triggered");
        if (col.gameObject.tag == "Player") {
            FindObjectOfType<GameManager>().GenerateNextHall(transform.parent.gameObject);


            print(transform.parent.gameObject.GetComponent<Hallway>().GetGoodness());
            Destroy(this.gameObject);
        }
    }
}
