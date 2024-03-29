﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbueloSpook : MonoBehaviour {

    // Abuelo himself
    public Transform abueloPrefab;
    private bool abueloExists = false;
    private Transform abuelo;

    // origin and destination positions of abuelo (relative to parent object of script)
    public Transform origin;
    public Transform destination;

    // speed at which abuelo moves
    public float speed = 3f;
    private float startTime;
    private float journeyLength;

    private void Start()
    {
        // calculate the distance between the origin and destination
        journeyLength = Vector3.Distance(origin.position, destination.position);
    }

    public void Spook () {
        // instantiate the abuelo prefab at the origin position and correct rotation
        abuelo = Instantiate(abueloPrefab, origin.position, transform.rotation);
        abuelo.GetComponent<AudioSource>().Play();

        abueloExists = true;
        startTime = Time.time;

        // disable the trigger gameobject
        GetComponent<BoxCollider>().enabled = false;
	}

    private void Update()
    {
        // if abuelo was spawned
        if (abueloExists)
        {
            // move abuelo from origin to destination smoothly
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionCovered = distanceCovered / journeyLength;
            abuelo.transform.localPosition = Vector3.Lerp(origin.position, destination.position, fractionCovered);
            
            // check if abuelo reached his destination and delete him once he did
            if (abuelo.localPosition == destination.position)
            {
                abueloExists = false;
                Destroy(abuelo.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        Spook();
    }
}
