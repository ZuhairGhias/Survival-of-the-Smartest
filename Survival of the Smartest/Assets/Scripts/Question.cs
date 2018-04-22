using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question {

    public string question;
    public string correctAnswer;
    public string wrongAnswer;

    public Question(string question, string correctAnswer, string wrongAnswer) {
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.wrongAnswer = wrongAnswer;
    }

    public static Question RandomQuestion() {
        return new Question("What is 9 + 10?", "19", "21");
    }

}
