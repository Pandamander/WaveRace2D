using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerValue;
    public bool timerRunning = true;
    [SerializeField] private TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timerValue += Time.deltaTime;
        }

        timerText.text = timerValue.ToString("0.0");
    }

    public void RestartTimer()
    {
        timerValue = 0f;
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
}
