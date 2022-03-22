using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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
    [SerializeField] private float minimumSpeed = 5f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float maxMaxSpeed = 12f; 
    [SerializeField] private Timer timer;
    [SerializeField] private float powerMeterDownTimer = 5f;
    //[SerializeField] private TMP_Text powerMeter;

    public bool knockedOff;
    public bool m_Grounded;
    private bool m_LandOnHead;
    private float k_GroundedRadius = 0.05f;

    [SerializeField] private LayerMask m_WhatIsGround;	// A mask determining what is ground to the character

    public float flipCounter1;
    public float flipCounter2;
    public int numberFlips;

    private float powerMeterCounter;

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
        flipCounter1 = flipCounter2 = 0f;
        numberFlips = 0;
        maxSpeed = minimumSpeed;
        ChangeMaxSpeed(0);
        FindObjectOfType<OnOffUI>().HideUI();
    }

    void Update()
    {
        PowerMeterDown();

    }

    void FixedUpdate() // Adjusting Rigidbody. Use force, same time between calls
    {
        // Accelerate. Only works if not knocked off
        if (Input.GetKey(KeyCode.UpArrow) && !knockedOff)
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

        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxSpeed); // This is where the max speed gets applied

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
                
                //if (!wasOnHead)
                    LandedOnHead();
            }
        }

        LimitAngularVelocity();
        CheckForBackflip();
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
        //float speedAsFloat = (rigidBody.velocity.magnitude / maxSpeed) * 110f;
        float speedAsFloat = (rigidBody.velocity.magnitude) * 10 + 4;
        return (int)Math.Floor(speedAsFloat);

        // Power; 5.2, max speed = 52 mph
    }

    public void LandedOnHead()
    {
        m_LandOnHead = true;
        knockedOff = true;
        GetComponent<SpriteRenderer>().color = new Color32(150, 50, 50, 255);

        FindObjectOfType<EndOfRaceScoring>().EndRaceGiveScore(-1f);
    }

    private void CheckForBackflip()
    { 

        if (rigidBody.rotation > flipCounter1)
        {
            flipCounter2 += rigidBody.rotation - flipCounter1;
            flipCounter1 = rigidBody.rotation;
        }

        if (flipCounter2 >= 360) // they did a backflip!
        {
            flipCounter2 = 0;
            numberFlips += 1;
            powerMeterCounter = 0f; // Reset the power meter down
            ChangeMaxSpeed(1);
        }

    }

    private void ChangeMaxSpeed(float howMuch)
    {
        // This updates the max speed based on how many flips have been done, and updates the power UI

        maxSpeed += howMuch;

        if (maxSpeed > maxMaxSpeed)
            maxSpeed = maxMaxSpeed;

        //powerMeter.text = "Power: " + maxSpeed;
        FindObjectOfType<MeterUI>().ChangeCurrentValue((int)maxSpeed - (int)minimumSpeed);
    }

    private void PowerMeterDown()
    {
        // This reduces the power meter on a timer regularly
        powerMeterCounter += Time.deltaTime;

        if (powerMeterCounter > powerMeterDownTimer)
        {
            powerMeterCounter = 0f; // Reset
            if (maxSpeed > minimumSpeed)
                ChangeMaxSpeed(-1);
            
        }
    }
}

