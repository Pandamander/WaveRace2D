using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] WaveRaceMovement player;
    [SerializeField] bool tracking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(player.transform.position);

        if (tracking)
            transform.position = screenPos;

    }
}
