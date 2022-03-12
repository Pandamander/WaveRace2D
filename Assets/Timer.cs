using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerNumber;
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
            timerNumber += Time.deltaTime;
        }

        timerText.text = timerNumber.ToString("0.0");
    }

    public void RestartTimer()
    {
        timerNumber = 0f;
        timerRunning = true;
    }
}
