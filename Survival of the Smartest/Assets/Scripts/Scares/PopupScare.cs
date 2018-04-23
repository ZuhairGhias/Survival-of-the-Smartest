using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScare : MonoBehaviour
{
    public GameObject abuelo;
    public Transform spawnLocation;
    public AudioSource soundSource;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Scare());
    }

    private IEnumerator Scare()
    {
        // pop up abuelo in front of the player for a brief moment and play a spooky scream
        GameObject abueloObject = Instantiate(abuelo, spawnLocation.position, spawnLocation.rotation, spawnLocation);
        soundSource.Play();

        yield return new WaitForSeconds(0.35f);

        Destroy(abueloObject.gameObject);
    }
}
