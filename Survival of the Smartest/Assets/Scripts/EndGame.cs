using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    // transforms and speed
    public GameObject abuelo;
    public Transform spawnLocation;
    public AudioSource soundSource;
    public Transform player;
    public float speed = 5f;

    // is the game over?
    private bool gameOver = false;

    public void StartAbueloChase()
    {
        // spawn abuelo
        abuelo = Instantiate(abuelo, spawnLocation.position, spawnLocation.rotation, spawnLocation.transform);

        gameOver = true;
    }

    void Update()
    {
        if (gameOver)
        {
            // move abuelo towards the player
            float step = speed * Time.deltaTime;
            spawnLocation.transform.position = Vector3.MoveTowards(spawnLocation.transform.position, player.position, step);
        }
    }
}
