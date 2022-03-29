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
    [SerializeField] private float topSpeed = 70f;
    [SerializeField] private float baseSpeed = 20f;
    
    [SerializeField] private float powerPerFlip = 10f;

    [SerializeField] private Timer timer;
    [SerializeField] private float powerDrainSpeed = -1f;
    [SerializeField] private HealthBar powerMeterUI;
    [SerializeField] private ParticleSystem wakeFX;
    //[SerializeField] private TMP_Text powerMeter;

    private float powerMeterLeft = 10f;
    [SerializeField] private float maxPowerMeter = 10f;

    public bool raceStopped;
    public bool m_Grounded;
    private bool m_LandOnHead;
    private float k_GroundedRadius = 0.5f;

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
        raceStopped = false;
        rigidBody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        rigidBody.angularVelocity = 0f;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        timer.RestartTimer();
        flipCounter1 = flipCounter2 = 0f;
        numberFlips = 0;
        //maxSpeed = minimumSpeed;

        //ChangeMaxSpeed(0);
        SetMaxSpeed(baseSpeed);
        SetPowerMeter(0f);

        FindObjectOfType<OnOffUI>().HideUI();

        var checkpoints = GameObject.FindObjectsOfType<Checkpoint>();
        var objectCount = checkpoints.Length;
        foreach (var obj in checkpoints) // loops through each buoy and resets them so they aren't marked as passed
        {
            obj.ResetCheckpoint();
        }
    }

    void Update()
    {
        if (m_Grounded)
        {
            wakeFX.Play();
        }
        else
        {
            wakeFX.Stop();
        }
    }

    public void StopEngine()
    {
        raceStopped = true;
    }    

    void FixedUpdate() // Runs every 0.02 seconds. Adjusting Rigidbody. Use force, same time between calls
    {
        // Accelerate. Only works if not knocked off
        if ((Input.GetKey(KeyCode.UpArrow) && !raceStopped) || (Input.GetKey(KeyCode.RightArrow) && !raceStopped))
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

            //ChangeMaxSpeed(powerDrainSpeed); // Accelerating uses up the power meter
            ChangePowerMeter(powerDrainSpeed);
            FindObjectOfType<AudioManager>().Play("Engine");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().StopPlaying("Engine");
        }

        // Backflip
        if (Input.GetKey(KeyCode.LeftArrow) && !raceStopped)
        {
            rigidBody.AddForce(new Vector2(0f, backFloatSpeed) * Time.deltaTime); // float up a little bit
            rigidBody.AddTorque(backRotationSpeed);
        }


        if (Input.GetKey(KeyCode.R)) // reset. Need to move this to the Game Manager or Level Manager
        {
            transform.position = startPosition.position;
            ResetJetSki();
        }

        if (raceStopped)
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
        if (!m_LandOnHead && !raceStopped) // should only happen once
        {
            m_LandOnHead = true;
            raceStopped = true;
            GetComponent<SpriteRenderer>().color = new Color32(150, 50, 50, 255);
            // TODO: Here is where we put the animation of the guy falling off

            FindObjectOfType<EndOfRaceScoring>().EndRaceGiveScore(-1f);
        }
        
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

            //ChangeMaxSpeed(powerPerFlip);
            SetMaxSpeed(topSpeed);
            ChangePowerMeter(powerPerFlip);
            FindObjectOfType<HypeText>().ShowHypeText("NICE FLIP!");
            FindObjectOfType<AudioManager>().Play("Flip");

        }

    }

    private void SetMaxSpeed(float howMuch)
    {
        // This updates the max speed based on how many flips have been done, and updates the power UI
        
        maxSpeed = howMuch;

        if (maxSpeed > maxMaxSpeed)
            maxSpeed = maxMaxSpeed;
        if (maxSpeed < minimumSpeed)
            maxSpeed = minimumSpeed;

        //powerMeterUI.SetHealth(powerMeterLeft);

    }

    private void SetPowerMeter(float howMuch)
    {
        powerMeterLeft = howMuch;

        if (powerMeterLeft <= 0)
        {
            powerMeterLeft = 0;
            maxSpeed = baseSpeed;
        }

        if (powerMeterLeft > maxPowerMeter)
        {
            powerMeterLeft = maxPowerMeter;
        }

        powerMeterUI.SetHealth(powerMeterLeft);
    }

    private void ChangePowerMeter(float howMuch)
    {
        powerMeterLeft += howMuch;
        

        if (powerMeterLeft <= 0)
        {
            powerMeterLeft = 0;
            maxSpeed = baseSpeed;
        }

        if (powerMeterLeft > maxPowerMeter)
        {
            powerMeterLeft = maxPowerMeter;
        }

        powerMeterUI.SetHealth(powerMeterLeft); // Set the UI
    }

    
}


