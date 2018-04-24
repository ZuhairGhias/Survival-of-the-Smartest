using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hallway : MonoBehaviour
{
    [Header("Blackboard References")]
    public TextMeshProUGUI rightAnswer;
    public TextMeshProUGUI leftAnswer;
    public TextMeshProUGUI question;

    [Header("Hallway References")]
    [Tooltip("The position and rotation the left hall will begin")]
    public Transform leftHallPosition;
    [Tooltip("The position and rotation the right hall will begin")]
    public Transform rightHallPosition;
    [Tooltip("The enter trigger for this hall with EnterTriggerScript attached")]
    public Collider hallEnterTrigger;

    [Header("Spookiness Settings")]
    public float maxLightIntensity = 1f;
    public float minLightIntensity = 0.1f;
    public float lightDimmingRate = 1f;

    [Header("Scare Settings")]
    public bool test;
    public GameObject testScare = null;
    public GameObject[] easyScares;
    public GameObject[] mediumScares;
    public GameObject[] hardScares;

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

    public void SetSpookiness(int spookiness)
    {
        this.spookiness = spookiness;

        StartCoroutine(DimLights(spookiness));
        // put spooky logic here

    }

    public void SetRandomScare() {
        print(spookiness);
        if (testScare != null && test) {
            testScare.SetActive(true);
        }
        else if (spookiness < 10 && easyScares.Length != 0) {
            int scareIndex = Random.Range(0, easyScares.Length);
            easyScares[scareIndex].SetActive(true);
        } else if(spookiness < 20 && mediumScares.Length != 0) {
            int scareIndex = Random.Range(0, mediumScares.Length);
            mediumScares[scareIndex].SetActive(true);
        }
        else if (spookiness < 30 && hardScares.Length != 0) {
            int scareIndex = Random.Range(0, hardScares.Length);
            hardScares[scareIndex].SetActive(true);
        }
    }
    private IEnumerator DimLights(float spookiness)
    {
        Light[] lights = GetComponentsInChildren<Light>();

        // initialize light intensity
        float initialIntensity = maxLightIntensity - ((spookiness - 10) / 30) * (maxLightIntensity - minLightIntensity);
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].intensity > initialIntensity) {
                lights[i].intensity = initialIntensity;
                lights[i].GetComponentInParent<Renderer>().material.SetColor("_EmissionColor", new Color(initialIntensity, initialIntensity, initialIntensity, 0));
            }
            
        }

        //gradually reduce light intensity
        float targetIntensity = maxLightIntensity - (spookiness / 30) * (maxLightIntensity - minLightIntensity);
        while (lights[0].intensity > targetIntensity) {
            for (int i = 0; i < lights.Length; i++) {
                float newIntensity = lights[i].intensity - lightDimmingRate / 1000;
                lights[i].intensity = newIntensity;
                lights[i].GetComponentInParent<Renderer>().material.SetColor("_EmissionColor", new Color(newIntensity, newIntensity, newIntensity, 0));
            }
            yield return null;
        }
        yield return null;
    }
}