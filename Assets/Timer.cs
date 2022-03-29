using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerValue;
    public bool timerRunning = true;
    [SerializeField] public float startingValue = 30f;
    [SerializeField] private TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        RestartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timerValue -= Time.deltaTime;
            if (timerValue < 0f && timerRunning)
                TimerRunOut();
        }

        timerText.text = timerValue.ToString("0.0");
    }

    public void RestartTimer()
    {
        timerValue = startingValue;
        timerRunning = true;
    }

    public float GetTimerValue()
    {
        return timerValue;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void AddTime(float howMuch)
    {
        timerValue += howMuch;
    }

    public void TimerRunOut()
    {
        timerRunning = false;
        timerValue = 0f; // set to 0 in case it went a little bit negative
        FindObjectOfType<EndOfRaceScoring>().OutOfTime();
        FindObjectOfType<WaveRaceMovement>().StopEngine();
        FindObjectOfType<AudioManager>().Play("OuttaTime");

    }
}
