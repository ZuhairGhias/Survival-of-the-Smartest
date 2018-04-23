using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Hallway : MonoBehaviour
{

    public TextMeshProUGUI rightAnswer;
    public TextMeshProUGUI leftAnswer;
    public TextMeshProUGUI question;

    [Tooltip("The position and rotation the left hall will begin")]
    public Transform leftHallPosition;
    [Tooltip("The position and rotation the right hall will begin")]
    public Transform rightHallPosition;
    [Tooltip("The enter trigger for this hall with EnterTriggerScript attached")]
    public Collider hallEnterTrigger;

    public float minLightIntensity = 0f;
    public float lightDimmingRate = 0.05f;

    private bool isGoodHall = true; // Tracks whether this hall is the correct or wrong hall
    private bool bias = true; // bias == true <=> right hall is good
    private int spookiness; // how spooky is the hallway

    public void SetQuestion(Question question, bool bias)
    {
        this.question.SetText(question.question);
        if (bias == true)
        {
            this.rightAnswer.SetText(question.correctAnswer);
            this.leftAnswer.SetText(question.wrongAnswer);
        }
        else
        {
            this.rightAnswer.SetText(question.wrongAnswer);
            this.leftAnswer.SetText(question.correctAnswer);
        }
        this.bias = bias;


    }

    public void SetGoodness(bool isGoodHall)
    {
        this.isGoodHall = isGoodHall;
    }

    public bool GetGoodness()
    {
        return this.isGoodHall;
    }

    public bool GetBias() {
        return this.bias;
    }

    internal void SetSpookiness(int spookiness)
    {
        this.spookiness = spookiness;

        StartCoroutine(DimLights(spookiness));
        // put spooky logic here

    }


    private IEnumerator DimLights(float spookiness)
    {
        Light[] lights = GetComponentsInChildren<Light>();

        // initialize light intensity
        float initalIntensity = 1 - ((spookiness - 10) / 30) * (1 - minLightIntensity);
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].intensity > initalIntensity) {
                lights[i].intensity = initalIntensity;
            }
            
        }

        //gradually reduce light intensity
        float targetIntensity = 1 - (spookiness / 30) * (1 - minLightIntensity);
        while (lights[0].intensity > targetIntensity) {
            for (int i = 0; i < lights.Length; i++) {
                lights[i].intensity = lights[i].intensity - lightDimmingRate/1000;
            }
            yield return null;
        }
        yield return null;
    }
}