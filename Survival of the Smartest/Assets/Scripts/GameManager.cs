using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject currentHall;
    public GameObject hallPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateNextHall(GameObject currentHall) {
        this.currentHall = currentHall;
        GameObject rightHall = Instantiate(hallPrefab, currentHall.transform.Find("HallRight").position, currentHall.transform.Find("HallRight").rotation);


    }
}
