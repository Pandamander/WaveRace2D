using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoopParallax : MonoBehaviour
{

    public Transform cameraTransform; // maybe make this public?
    public Vector2 parallaxEffectMultiplier; // this determines the amount of parallax
    public bool repeatHorizontal = false;
    public bool repeatVertical = false;
    private float singleScreenUnitWidth = 64.0f; // the width of 1 screen in world units
    private float singleScreenUnitHeight = 36.0f; // the height of 1 screen in world units

    private Vector3 lastCameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        lastCameraPosition = cameraTransform.position;

        Tilemap myTilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; // the amount the camera has moved since the last frame
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y); // update the transform of the object this script is on

        lastCameraPosition = cameraTransform.position; // update last camera position for next frame update

        // set up the tilemap for repeating horizontally
        if (repeatHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= singleScreenUnitWidth)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % singleScreenUnitWidth;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }
        }

        // set up the tilemap for repeating vertically
        if (repeatVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= singleScreenUnitHeight)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % singleScreenUnitHeight;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
            }
        }

    }
}
