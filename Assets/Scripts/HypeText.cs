using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HypeText : OnOffUI
{
    [SerializeField] private TMP_Text text;
    private bool blinking;
    private bool textOn;
    private float counter;
    [SerializeField] private float blinkDuration = 1f;
    [SerializeField] private float numTotalBlinks = 5;
    private float blinksSoFar;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (blinking)
        {
            Debug.Log("Blinking" + counter);

            counter += Time.deltaTime;
            if (counter > blinkDuration)
            {
                textOn = !textOn;
                if (textOn)
                {
                    ShowUI();
                }
                else
                {
                    HideUI();
                }
                blinksSoFar += 1;
                counter = 0;
            }

            if (blinksSoFar >= numTotalBlinks)
            {
                TurnOffHypeText();
            }
        }

        
    }

    public void ShowHypeText(string whatText)
    {
        text.text = whatText;
        textOn = true;
        counter = 0;
        blinking = true;
        blinksSoFar = 0f;

        ShowUI();
    }

    private void TurnOffHypeText()
    {
        textOn = false;
        blinking = false;
        HideUI();
    }
}
