using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallEnterTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            FindObjectOfType<GameManager>().GenerateNextHall(transform.parent.gameObject);
        }
	}

    void OnTriggerEnter(Collider col) {
        print("Triggered");
        if (col.gameObject.tag == "Player") {
            FindObjectOfType<GameManager>().GenerateNextHall(transform.parent.gameObject);

            // call the Abuelo spook
            GetComponentInParent<AbueloSpook>().Spook();

            print(transform.parent.gameObject.GetComponent<Hallway>().GetGoodness());
            Destroy(this.gameObject);
        }
    }
}
