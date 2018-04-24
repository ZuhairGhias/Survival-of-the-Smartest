using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public FPSMovementControl playerMovement;
    public FPSCameraControl playerCamera;

    private GameObject currentHall = null;
    private GameObject oldHall = null;
    private GameObject rightHall = null;
    private GameObject leftHall = null;
    private GameObject oldHall2 = null;
    private int spookiness = 0;

    public GameObject hallPrefab;
    public float maxFogIntensity = 0.2f;
    public float fogRate = 1f;

    private int rightAnswers = 0;
    private int wrongAnswers = 0;
    private int spookMultiplierWrong = 10;
    private int spookMultiplierRight = 2;

    public GameObject winUI;
    public GameObject loseUI;
    private bool gameOver = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (gameOver) {
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Instantiates the next two halls in the game and deletes previous ones.</summary>
    /// <param name="currentHall">The hall that was entered.</param>
    public void GenerateNextHall(GameObject currentHall) {

        if (rightAnswers == 10) {
            winUI.SetActive(true);

            // disable player controls
            playerMovement.enabled = false;
            playerCamera.enabled = false;

            gameOver = true;

        } else if(wrongAnswers == 3){
            loseUI.SetActive(true);

            // disable player controls
            playerMovement.enabled = false;
            playerCamera.enabled = false;

            gameOver = true;
        }

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
        rightHall = Instantiate(hallPrefab, currentHall.GetComponent<Hallway>().rightHallPosition.position, currentHall.GetComponent<Hallway>().rightHallPosition.rotation);
        leftHall = Instantiate(hallPrefab, currentHall.GetComponent<Hallway>().leftHallPosition.position, currentHall.GetComponent<Hallway>().leftHallPosition.rotation);

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
            StartCoroutine(Fog());
        }
        else {
            rightAnswers++;
        }

        // Calculate spookiness
        spookiness = Mathf.Min(wrongAnswers * spookMultiplierWrong + rightAnswers * spookMultiplierRight, 30);

        // Set spookiness of current halls
        rightHall.GetComponent<Hallway>().SetSpookiness(spookiness);
        leftHall.GetComponent<Hallway>().SetSpookiness(spookiness);
        currentHall.GetComponent<Hallway>().SetSpookiness(spookiness);

        // Set scare for wrong hall
        if (bias)
        {
            leftHall.GetComponent<Hallway>().SetRandomScare();
        }
        else {
            rightHall.GetComponent<Hallway>().SetRandomScare();
        }



    }

    private IEnumerator Fog()
    {
         float targetDensity = maxFogIntensity * spookiness / 30;

        while (RenderSettings.fogDensity < targetDensity)
        {
            RenderSettings.fogDensity = RenderSettings.fogDensity + fogRate / 1000;
            yield return null;
        }
        yield return null;
    }
}
