using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] GameObject endingUI;

    [SerializeField] TMP_Text endingText;


    // This script handles tracking the score and also the end of the game

    void Start()
    {
        endingUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    public void HideUI()
    {
        endingUI.SetActive(false);
    }

    public void ShowRestartDialog()
    {
        endingUI.SetActive(true);

        endingText.text = "Press [R] to Restart";


    }


}
