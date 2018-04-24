using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question {

    public string question;
    public string correctAnswer;
    public string wrongAnswer;
    private static Question[] questions = null;

    public Question(string question, string correctAnswer, string wrongAnswer) {
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.wrongAnswer = wrongAnswer;
    }

    public static Question RandomQuestion() {
        if (questions == null) {
            questions = new Question[] {
            new Question("What chemical element gives the blood of a lobster a bluish tint?","Copper","Iron"),
            new Question("Bronze is an alloy consisting primarily of what two elements?","Copper & Tin","Aluminium & Iron"),
            new Question("Which is the most abundant metal in the earth’s crust?","Aluminum","Iron"),
            new Question("Cubic zirconia is a synthesized material often used in place of what precious stone?","Diamond","Ruby"),
            new Question("What is the most common blood type in humans?","O+","O"),
            new Question("Which gland in the human body regulates metabolism?","Thyroid","Liver"),
            new Question("Penicillin was discovered in 1928 by which Scottish scientist?","Sir Alexander Fleming","Paul Ehrlich"),
            new Question("An animal that lives part of its life on land and part in water is known as what?","Amphibian","Ambidextrous"),
            new Question("What was the first console video game that allowed the game to be saved?","The Legend of Zelda","Super Mario Bros"),
            new Question("Regarding data storage, what does the acronym SSD stand for?","Solid State Drive","Storage State Drive"),
            new Question("What year was Facebook founded?","2004","2008"),
            new Question("What is the name of the main protagonist in the Legend of Zelda series of video games?","Link","Zelda"),
            new Question("In what country would you find Mount Kilimanjaro?","Tanzania","Tibet"),
            new Question("How many red stripes are there on the United States flag?","Seven","Nine"),
            new Question("What is the official language of Greenland?","Greenlandic","Scottish"),
            new Question("Macau is an autonomous territory belonging to which country?","China","Uruguay"),
            new Question("In what year did the great fire of London take place?","1666","1766"),
            new Question("Who was president of the United States when bombs were dropped on Hiroshima and Nagasaki?","Harry S. Truman","Dwight D. Eisenhower"),
            new Question("Who were the first two astronauts that landed on the moon in 1969?","Neil Armstrong and Buzz Aldrin","Neil Armstrong and John Young"),
            new Question("Which christian missionary is said to have banished all the snakes from Ireland?","Saint Patrick","David Livingstone"),
            new Question("What type of animal is Looney Tunes’ fictional character Foghorn J. Leghorn?","Rooster","Tasmanian Devil"),
            new Question("In our solar system which two planets rotate clockwise?","Venus & Uranus","Mars and Pluto"),
            new Question("What is the favorite food of the Teenage Mutant Ninja Turtles?","Pizza","Hotdogs"),
            new Question("The term “déjà vu” comes from what language?","French","Spanish"),
            new Question("Ireland suffered the Great Famine beginning in 1845 due to the collapse of what crop?","Potato","Rice"),
            new Question("What was Walt Disney’s middle name?","Elias","Allan"),
            new Question("Which mammal has the longest gestation period?","Elephant","Kangaroo"),
            new Question("What is the three letter airport code for the Los Angeles International Airport?","LAX","LAS")
            };
        }

        return questions[Random.Range(0, questions.Length)];
    }

}
