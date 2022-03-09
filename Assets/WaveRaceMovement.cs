using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveRaceMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float forwardSpeed = 100f;
    [SerializeField] private float downSpeed = 70f;
    [SerializeField] private float rotationSpeed = 500;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform topOfJetSki;
    [SerializeField] private Transform bottomOfJetSki;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private string speedometer;

    public bool knockedOff;
    private bool m_Grounded;
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !knockedOff)
        {
            rigidBody.AddForce(new Vector2(forwardSpeed, downSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !knockedOff)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
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
        speedometer = rigidBody.velocity.ToString();

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
                    Debug.Log("On Ground");
                // Debug.Log("Ground is " + colliders[i].name); // BUG: Haven't figured this out, the ground is colliding all the time so jump get set to false immeidately
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
                // Debug.Log("Ground is " + colliders[i].name); // BUG: Haven't figured this out, the ground is colliding all the time so jump get set to false immeidately
            }
        }
    }
}

/*
 Next up:
Look at tiny wings, see if there is some kind of acceleration that's happening on the down ramps. Then build that
Play aroudn with the height of waves, speed, settings
Add in a timer to finish
 */
