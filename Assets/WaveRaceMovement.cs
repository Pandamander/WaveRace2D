using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WaveRaceMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float accelSpeed = 100f;
    [SerializeField] private float accelDownSpeed = 70f;
    [SerializeField] private float forwardRotationSpeed = -1;
    [SerializeField] private float diveSpeed = 70f;
    [SerializeField] private float backFloatSpeed = 70f;
    [SerializeField] private float backRotationSpeed = 1;
    [SerializeField] private float maxAngularVelocity = 100f;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform topOfJetSki;
    [SerializeField] private Transform bottomOfJetSki;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private Timer timer;

    public bool knockedOff;
    public bool m_Grounded;
    private bool m_LandOnHead;
    private float k_GroundedRadius = 0.05f;
    private int numberFlips;
    private float flipDegrees;
    private float initialRotation;
    [SerializeField] private LayerMask m_WhatIsGround;	// A mask determining what is ground to the character


    // Start is called before the first frame update
    void Start()
    {
        ResetJetSki();
    }

    void ResetJetSki()
    {
        knockedOff = false;
        rigidBody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        rigidBody.angularVelocity = 0f;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        timer.RestartTimer();

    }

    
    void FixedUpdate() // Adjusting Rigidbody. Use force, same time between calls
    {

        // Accelerate. Only works if not knocked off
        if (Input.GetKey(KeyCode.RightArrow) && !knockedOff)
        {
            if (m_Grounded) //if on the water
            {
                rigidBody.AddForce(new Vector2(accelSpeed, accelDownSpeed * -1f) * Time.deltaTime); // move forward
            }
            else // if in the air
            {
                rigidBody.AddForce(new Vector2(0f, diveSpeed) * Time.deltaTime); // dive down
                rigidBody.AddTorque(forwardRotationSpeed); // Tilt forward
            }
            
        }

        // Backflip
        if (Input.GetKey(KeyCode.LeftArrow) && !knockedOff)
        {
            rigidBody.AddForce(new Vector2(0f, backFloatSpeed) * Time.deltaTime); // float up a little bit
            rigidBody.AddTorque(backRotationSpeed);
        }


        if (Input.GetKey(KeyCode.R)) // reset. Need to move this to the Game Manager or Level Manager
        {
            transform.position = startPosition.position;
            ResetJetSki();
        }

        if (knockedOff)
        {
            rigidBody.AddForce(new Vector2(0f, -100) * Time.deltaTime);
        }

        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxSpeed);

        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(bottomOfJetSki.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                {
                    //Debug.Log("Landed on Ground");
                }

            }
        }


        bool wasOnHead = m_LandOnHead;
        m_LandOnHead = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] collidersHead = Physics2D.OverlapCircleAll(topOfJetSki.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < collidersHead.Length; i++)
        {
            if (collidersHead[i].gameObject != gameObject)
            {
                m_LandOnHead = true;
                //if (!wasOnHead)
                    LandedOnHead();
            }
        }

        LimitAngularVelocity();
        CheckForBackflip();
    }

    private void Update() // Simple timers, receiving input
    { 
        

    }

    private void LimitAngularVelocity()
    {
        // Keeps it from spinning too fast
        if (rigidBody.angularVelocity > maxAngularVelocity)
            rigidBody.angularVelocity = maxAngularVelocity;
        if (rigidBody.angularVelocity < maxAngularVelocity * -1f)
            rigidBody.angularVelocity = maxAngularVelocity * -1;
    }

    public int GetCurrentSpeed()
    {
        float speedAsFloat = (rigidBody.velocity.magnitude / maxSpeed) * 105f;
        return (int)Math.Floor(speedAsFloat);
    }

    public void LandedOnHead()
    {
        knockedOff = true;
        GetComponent<SpriteRenderer>().color = new Color32(150, 50, 50, 255);
    }

    private void CheckForBackflip()
    {

        if (rigidBody.rotation > 360)
        {
            Debug.Log("Backflip");
        }
    }
}

