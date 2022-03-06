using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveMovement : MonoBehaviour
{

    float timeElapsed;
    [SerializeField] float waveSpeed = 1f;
    [SerializeField] float waveHeight = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        float waveValue = Mathf.Sin(timeElapsed * waveSpeed) * waveHeight;
        transform.position = new Vector3(transform.position.x, transform.position.y + waveValue, transform.position.z);
    }
}
