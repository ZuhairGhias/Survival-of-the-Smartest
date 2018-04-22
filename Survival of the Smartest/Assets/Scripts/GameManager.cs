using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject currentHall = null;
    private GameObject oldHall = null;
    private GameObject rightHall = null;
    private GameObject leftHall = null;
    private GameObject oldHall2 = null;
    private int spookLevel = 0;
    private int spookNumber = 0;

    public GameObject hallPrefab;
    public int numberOfSpooks;

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

        bool bias = currentHall.GetComponent<Hallway>().GetBias();



        rightHall = Instantiate(hallPrefab, currentHall.transform.Find("HallRight").position, currentHall.transform.Find("HallRight").rotation);
        rightHall.GetComponent<Hallway>().SetQuestion(Question.RandomQuestion(), Random.Range(0,2) == 1);
        rightHall.GetComponent<Hallway>().SetGoodness(bias);
        leftHall = Instantiate(hallPrefab, currentHall.transform.Find("HallLeft").position, currentHall.transform.Find("HallLeft").rotation);
        leftHall.GetComponent<Hallway>().SetQuestion(Question.RandomQuestion(), Random.Range(0, 2) == 1);
        leftHall.GetComponent<Hallway>().SetGoodness(!bias);

        this.currentHall = currentHall;

        if (!currentHall.GetComponent<Hallway>().GetGoodness()) {
            spookLevel++;
            spookNumber = ChooseNewSpook();
        }

        if (bias)
        {
            leftHall.GetComponent<Hallway>().SetSpook(spookNumber);
        }
        else {
            rightHall.GetComponent<Hallway>().SetSpook(spookNumber);
        }
        
    }

    private int ChooseNewSpook()
    {
        return spookLevel;
    }
}
