using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRaceMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public float forwardSpeed = 100f;
    [SerializeField] public float downSpeed = 70f;
    [SerializeField] public float rotationSpeed = 500;
    [SerializeField] public Transform startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddForce(new Vector2(forwardSpeed, downSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R)) // reset
        {
            transform.position = startPosition.position;
        }

        /*
        if (rigidBody.angularVelocity < maxAngularVelocity)
        {
            rigidBody.angularVelocity = maxAngularVelocity;
            Debug.Log(maxAngularVelocity);
        }
        */
        
        //Debug.Log(rigidBody.angularVelocity);
    }
}

/*
 Next up:
Look at tiny wings, see if there is some kind of acceleration that's happening on the down ramps. Then build that
Play aroudn with the height of waves, speed, settings
Add in a timer to finish
Download git, move in the other folder
 */
