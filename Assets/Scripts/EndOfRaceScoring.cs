using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class EndOfRaceScoring : MonoBehaviour
{

    [SerializeField] TMP_Text endingText;
    [SerializeField] Image trophyImage;
    [SerializeField] float[] winningTimes;
    [SerializeField] Sprite[] trophySprites;
    [SerializeField] private OnOffUI endingDialog;

    // Start is called before the first frame update
    void Start()
    {
        
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
        trophyImage.sprite = trophySprites[3];
    }

    public void EndRaceGiveScore(float finalTime)
    {
        Debug.Log("End");
        endingDialog.ShowUI();

        try
        {
            if (finalTime < 0) // If they lost or fell over, use -1
            {
                endingText.text = "Ouch! Try not to land on your head!" +
                    "\n\nPress [R] to Restart, [L] to Select Level";
                FindObjectOfType<AudioManager>().Play("FallOff");
                trophyImage.sprite = trophySprites[3];
            }
            else if (finalTime > winningTimes[0])
            {
                endingText.text = "Gold Trophy! Amazing job!!" +
                    "\n\nPress [R] to Restart, [L] to Select Level";
                FindObjectOfType<AudioManager>().Play("GoldFinish");
                trophyImage.sprite = trophySprites[2];
            }
            else if (finalTime > winningTimes[1])
            {
                endingText.text = "Silver Trophy! Great job!" +
                    "\n\nPress [R] to Restart, [L] to Select Level";
                FindObjectOfType<AudioManager>().Play("Finish");
                trophyImage.sprite = trophySprites[1];
            }
            else if (finalTime > winningTimes[2])
            {
                endingText.text = "Bronze Trophy! Good job!" +
                    "\n\nPress [R] to Restart, [L] to Select Level";
                FindObjectOfType<AudioManager>().Play("Finish");
                trophyImage.sprite = trophySprites[0];
            }
            else
            {
                endingText.text = "Too slow...try to improve." +
                    "\n\nPress [R] to Restart, [L] to Select Level";
                FindObjectOfType<AudioManager>().Play("Finish");
                trophyImage.sprite = trophySprites[3];
            }
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("You don't have enough values in the final race times, only " + winningTimes.Length);
        }
        



    }
}
