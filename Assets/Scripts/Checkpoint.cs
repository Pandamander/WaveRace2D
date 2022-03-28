using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
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
        FindObjectOfType<HypeText>().ShowHypeText("CHECKPOINT +" + timeToAdd.ToString() + "s");
        timer.AddTime(timeToAdd);
    }

    public void ResetCheckpoint()
    {
        checkPointCrossed = false;
    }
}
