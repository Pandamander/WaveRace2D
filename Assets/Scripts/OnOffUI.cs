using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OnOffUI : MonoBehaviour
{
    [SerializeField] GameObject EndUIToTurnOffOn;


    // This script handles tracking the score and also the end of the game

    void Start()
    {
        EndUIToTurnOffOn.SetActive(false);
        
    }


    public void HideUI()
    {
        EndUIToTurnOffOn.SetActive(false);
    }

    public void ShowUI()
    {
        EndUIToTurnOffOn.SetActive(true);
    }



}
