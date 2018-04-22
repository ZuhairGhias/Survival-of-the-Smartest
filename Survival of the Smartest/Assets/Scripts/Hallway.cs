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

        // put spooky logic here

    }
}