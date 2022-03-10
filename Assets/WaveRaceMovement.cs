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
    [SerializeField] private float accelRotationSpeed = 50;
    [SerializeField] private float diveSpeed = 70f;
    [SerializeField] private float backFloatSpeed = 70f;
    [SerializeField] private float backRotationSpeed = 500;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform topOfJetSki;
    [SerializeField] private Transform bottomOfJetSki;
    [SerializeField] private float maxSpeed = 10f;

    public bool knockedOff;
    public bool m_Grounded;
    private bool m_LandOnHead;
    private float k_GroundedRadius = 0.05f;
    [SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character


    // Start is called before the first frame update
    void Start()
    {
        ResetJetSki();
    }

    void ResetJetSki()
    {
        knockedOff = false;
        // TODO: make the rotataion and speed back to normal
        rigidBody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

    }

    // Update is called once per frame
    void FixedUpdate()
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
                transform.Rotate(new Vector3(0, 0, accelRotationSpeed) * Time.deltaTime); // rotate forward a little bit
            }
            
        }

        // Backflip
        if (Input.GetKey(KeyCode.LeftArrow) && !knockedOff)
        {
            rigidBody.AddForce(new Vector2(0f, backFloatSpeed) * Time.deltaTime); // float up a little bit
            transform.Rotate(new Vector3(0, 0, backRotationSpeed) * Time.deltaTime); // rotate back
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
                    Debug.Log("Landed on Ground");
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
                if (!wasOnHead)
                    Debug.Log("Land on head");
                    knockedOff = true;
            }
        }
    }

    public int GetCurrentSpeed()
    {
        float speedAsFloat = (rigidBody.velocity.magnitude / maxSpeed) * 105f;
        return (int)Math.Floor(speedAsFloat);
    }
}

