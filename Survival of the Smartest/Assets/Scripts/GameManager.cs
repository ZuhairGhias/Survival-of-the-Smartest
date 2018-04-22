using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject currentHall = null;
    private GameObject oldHall = null;
    private GameObject rightHall = null;
    private GameObject leftHall = null;
    private GameObject oldHall2 = null;

    public GameObject hallPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateNextHall(GameObject currentHall) {
        Destroy(oldHall);
        Destroy(oldHall2);
        oldHall = this.currentHall;

        if (GameObject.ReferenceEquals(currentHall, rightHall))
        {
            oldHall2 = leftHall;
        }
        else if (GameObject.ReferenceEquals(currentHall, leftHall))
        {
            oldHall2 = rightHall;
        }

        this.currentHall = currentHall;

        rightHall = Instantiate(hallPrefab, currentHall.transform.Find("HallRight").position, currentHall.transform.Find("HallRight").rotation);
        leftHall = Instantiate(hallPrefab, currentHall.transform.Find("HallLeft").position, currentHall.transform.Find("HallLeft").rotation);



    }
}
