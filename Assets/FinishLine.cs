using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private WaveRaceMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x) // if they've crossed the finish line
        {
            EndRace();
        }
    }

    void EndRace()
    {
        timer.timerRunning = false;
        FindObjectOfType<EndGameUI>().ShowRestartDialog();
    }

    
}
