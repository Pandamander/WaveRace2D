using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public float rotationSpeed;
    public float rotationMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * rotationSpeed) * rotationMagnitude * -1);
    }
}
