using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbueloSpook : MonoBehaviour {

    // Abuelo Prefab
    public Transform abueloPrefab;

    // origin and destination positions of abuelo (relative to parent object of script)
    public Vector3 originPosition;
    public Vector3 destinationPosition;

    // speed at which abuelo moves
    public float speed = 3f;
    private float startTime;
    private float journeyLength;

    private bool abueloExists = false;
    private Transform abuelo;

    private void Start()
    {
        // calculate the distance between the origin and destination
        journeyLength = Vector3.Distance(originPosition, destinationPosition);

        Spook();
    }

    public void Spook () {
        // instantiate the abuelo prefab at the origin position and correct rotation
        abuelo = Instantiate(abueloPrefab, originPosition, Quaternion.Euler(0f,180f,0f), gameObject.transform);
        abuelo.GetComponent<AudioSource>().Play();

        abueloExists = true;
        startTime = Time.time;
	}

    private void Update()
    {
        // if abuelo was spawned
        if (abueloExists)
        {
            // move abuelo from origin to destination smoothly
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionCovered = distanceCovered / journeyLength;
            abuelo.transform.localPosition = Vector3.Lerp(originPosition, destinationPosition, fractionCovered);
            
            // check if abuelo reached his destination and delete him once he did
            if (abuelo.localPosition == destinationPosition)
            {
                abueloExists = false;
                Destroy(abuelo.gameObject);
            }
        }
    }
}
