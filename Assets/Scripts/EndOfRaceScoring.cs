using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndOfRaceScoring : MonoBehaviour
{

    [SerializeField] TMP_Text endingText;
    [SerializeField] float[] winningTimes;
    private OnOffUI endingDialog;

    // Start is called before the first frame update
    void Start()
    {
        endingDialog = FindObjectOfType<OnOffUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OutOfTime()
    {
        endingDialog.ShowUI();
        endingText.text = "Not fast enough! Do more backflips to go faster!" +
                    "\n\nPress [R] to Restart";
    }

    public void EndRaceGiveScore(float finalTime)
    {
        endingDialog.ShowUI();

        try
        {
            if (finalTime < 0) // If they lost or fell over, use -1
            {
                endingText.text = "Ouch!" +
                    "\n\nPress [R] to Restart";
            }
            else if (finalTime < winningTimes[0])
            {
                endingText.text = "Gold Trophy! Amazing job!!" +
                    "\n\nPress [R] to Restart";
            }
            else if (finalTime < winningTimes[1])
            {
                endingText.text = "Silver Trophy! Great job!" +
                    "\n\nPress [R] to Restart";
            }
            else if (finalTime < winningTimes[2])
            {
                endingText.text = "Bronze Trophy! Good job!" +
                    "\n\nPress [R] to Restart";
            }
            else
            {
                endingText.text = "Too slow...try to improve." +
                    "\n\nPress [R] to Restart";
            }
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("You don't have enough values in the final race times, only " + winningTimes.Length);
        }
        



    }
}
