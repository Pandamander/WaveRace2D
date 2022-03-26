using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy : MonoBehaviour
{
    [SerializeField] private WaveRaceMovement player;
    [SerializeField] private Timer timer;
    [SerializeField] private float timeToAdd = 10f;
    private bool checkPointCrossed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x && !checkPointCrossed) // passed the buoy
        {
            CrossCheckPoint();
        }

    }

    void CrossCheckPoint()
    {
        checkPointCrossed = true;
        timer.AddTime(timeToAdd);
    }

    public void ResetBuoy()
    {
        checkPointCrossed = false;
    }
}
