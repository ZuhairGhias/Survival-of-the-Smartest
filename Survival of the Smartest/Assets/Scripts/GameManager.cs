using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject currentHall = null;
    private GameObject oldHall = null;
    private GameObject rightHall = null;
    private GameObject leftHall = null;
    private GameObject oldHall2 = null;
    private int spookiness = 0;

    public GameObject hallPrefab;
    private int rightAnswers = 0;
    private int wrongAnswers = 0;
    private int spookMultiplierWrong = 10;
    private int spookMultiplierRight = 2;
    private List<int> easySpooks;
    private List<int> mediumSpooks;
    private List<int> hardSpooks;
    private int currentScare = -1;

    // Use this for initialization
    void Start () {
        RefreshSpooks();
	}

    private void RefreshSpooks()
    {
        easySpooks = new List<int> { 0, 1, 2, 3, 4 };
        mediumSpooks = new List<int> { 5, 6, 7, 8, 9 };
        hardSpooks = new List<int> { 10, 11, 12 };

    }

    // Update is called once per frame
    void Update () {
		
	}


    /// <summary>
    /// Instantiates the next two halls in the game and deletes previous ones.</summary>
    /// <param name="currentHall">The hall that was entered.</param>
    public void GenerateNextHall(GameObject currentHall) {

        // These halls are not visible any more
        Destroy(oldHall);
        Destroy(oldHall2);

        // old hall is now the hall we left
        oldHall = this.currentHall;
        this.currentHall = currentHall;

        // old hall2 is the hall we did not enter
        if (GameObject.ReferenceEquals(currentHall, rightHall))
        {
            oldHall2 = leftHall;
        }
        else if (GameObject.ReferenceEquals(currentHall, leftHall))
        {
            oldHall2 = rightHall;
        }

        // bias == true <=> the correct answer is on the right side
        bool bias = currentHall.GetComponent<Hallway>().GetBias();


        // Instantiate new halls at the children named "HallRight" and "HallLeft" or the current hall
        rightHall = Instantiate(hallPrefab, currentHall.transform.Find("HallRight").position, currentHall.transform.Find("HallRight").rotation);
        leftHall = Instantiate(hallPrefab, currentHall.transform.Find("HallLeft").position, currentHall.transform.Find("HallLeft").rotation);

        // Set the halls with a question and random bias
        rightHall.GetComponent<Hallway>().SetQuestion(Question.RandomQuestion(), Random.Range(0, 2) == 1);
        leftHall.GetComponent<Hallway>().SetQuestion(Question.RandomQuestion(), Random.Range(0, 2) == 1);
        
        // Set which hall is the right/wrong one to enter
        rightHall.GetComponent<Hallway>().SetGoodness(bias);
        leftHall.GetComponent<Hallway>().SetGoodness(!bias);

        // Is this the right or wrong hall?
        if (!currentHall.GetComponent<Hallway>().GetGoodness())
        {
            wrongAnswers++;
            ChooseNewScare();
        }
        else {
            rightAnswers++;
        }

        // Calculate spookiness
        spookiness = wrongAnswers * spookMultiplierWrong + rightAnswers * spookMultiplierRight;

        // Set spookiness of current halls
        rightHall.GetComponent<Hallway>().SetSpookiness(spookiness);
        leftHall.GetComponent<Hallway>().SetSpookiness(spookiness);
        currentHall.GetComponent<Hallway>().SetSpookiness(spookiness);

        // Set scare for wrong hall
        if (bias)
        {
            SetScare(leftHall);
        }
        else {
            SetScare(rightHall);
        }



    }
    /// <summary>
    /// Sets up a unique predetermined scare in the wrong hall.</summary>
    /// <param name="wrongHall">The hall that should not be entered</param>
    private void SetScare(GameObject leftHall)
    {
        switch (currentScare) {
            case 1:
                // leftHall.GetComponent<Hallway>().RigLocker();
                break;
            case 2:
                // leftHall.GetComponent<Hallway>().RigLight();
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }
    /// <summary>
    /// Determines the scare to set up in the next wrong hall.</summary>
    private void ChooseNewScare()
    {
        // choose an easy scare
        if (spookiness < 10)
        {
            if (easySpooks.Count == 0)
            {
                RefreshSpooks();
            }
            int scareIndex = Random.Range(0, easySpooks.Count);
            currentScare = easySpooks[scareIndex];
            // gradually exhaust scares
            easySpooks.RemoveAt(scareIndex);
        }
        // choose a medium scare
        else if (spookiness < 20)
        {
            if (mediumSpooks.Count == 0)
            {
                RefreshSpooks();
            }
            int scareIndex = Random.Range(0, mediumSpooks.Count);
            currentScare = mediumSpooks[scareIndex];
            mediumSpooks.RemoveAt(scareIndex);
        }
        // choose a hard scare
        else {
            if (hardSpooks.Count == 0)
            {
                RefreshSpooks();
            }
            int scareIndex = Random.Range(0, hardSpooks.Count);
            currentScare = hardSpooks[scareIndex];
            hardSpooks.RemoveAt(scareIndex);
        }

    }
}
