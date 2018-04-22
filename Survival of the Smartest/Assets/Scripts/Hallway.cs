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

    private bool isGoodHall = true;
    private bool bias = true;

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

    internal void SetSpook(int spookNumber)
    {
        switch (spookNumber) {
            case 1:
                break;
        }
    }
}