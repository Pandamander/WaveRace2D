using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EndGame : MonoBehaviour
{
    private bool isGameOver;
    [SerializeField] GameObject endingUI;

    [SerializeField] TMP_Text scoreText;


    // This script handles tracking the score and also the end of the game

    void Start()
    {
        endingUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       


    }


    public void EndTheGame()
    {
        isGameOver = true;
        endingUI.SetActive(true);


        scoreText.text = "Great run!";

        //scoreText.text = "You've gone down with yer ship! \n\n Time Score: " + timeScore + "\nMoney Score: " + moneyScore + "\n\nTotal Score: " + totalScore + "\n\nPress Enter to Play Again";

    }


}
