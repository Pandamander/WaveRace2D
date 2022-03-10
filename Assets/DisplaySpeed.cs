using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySpeed : MonoBehaviour
{
    [SerializeField] private WaveRaceMovement jetSki;
    [SerializeField] private TMP_Text speedometer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedometer.text = jetSki.GetCurrentSpeed() + " km/h";
    }
}
