using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParallaxBackground : MonoBehaviour {

	[SerializeField] private float scrollSpeed = 2f;
	[SerializeField] private bool seamlessRepeating = false;
	[SerializeField] private float nonSeamlessTravelWidth= 2f;

	private float timeCounter = 0f;
	private Vector2 startPosition;
	private float worldUnitsOfSize;

	void Start () {
		// DOESN'T WORK QUITE YET
		// This script can be attached to anything that needs to scroll and also repeat
		// Must be added to a object that has a sprite renderer

		if (seamlessRepeating)
		{

			startPosition = transform.position;
			float pixelsPerUnit = 100f;
			worldUnitsOfSize = GetComponent<SpriteRenderer>().sprite.rect.width / pixelsPerUnit; // This doesn't work for scaled items
			Debug.Log(worldUnitsOfSize + ", " + GetComponent<SpriteRenderer>().sprite.rect.width);

			// Create the copy for scrolling
			GameObject SecondSpriteCreator = new GameObject(); // Instantiate a gameobject with a spritesheet, and make it this gameobject's child
			SpriteRenderer sr = SecondSpriteCreator.AddComponent<SpriteRenderer>(); // Add sprite renderer
			sr.sortingLayerID = GetComponent<SpriteRenderer>().sortingLayerID; // Set the layer
			sr.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder; // Set the order
			SecondSpriteCreator.name = "Second " + name;

			SecondSpriteCreator.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite; // Set the sprite to be the parent sprite

			Vector3 secondSpritePosition = new Vector3(transform.position.x - worldUnitsOfSize, transform.position.y, transform.position.z); // Set the position to be the right decision

			// Set layer to parent layer
			Instantiate(SecondSpriteCreator, secondSpritePosition, Quaternion.identity, transform);
			Destroy(SecondSpriteCreator);
		}
		else
        {
			// Any setup for the non-seamless
		}
		
	}
	
	void Update () {

		if (seamlessRepeating)
		{
			MoveSeamlessBG();
		}
		else
        {
			MovenonSeamlessBG();
        }
	}

	void MoveSeamlessBG()
	{

		timeCounter += Time.deltaTime;

		float newPosition = Time.deltaTime / 100 * scrollSpeed;
		//Debug.Log(transform.position.x + ", " + newPosition + ", " + worldUnitsOfSize);
		transform.position = new Vector3(Mathf.Repeat(transform.position.x + newPosition, worldUnitsOfSize * transform.localScale.x),
			transform.position.y,
			transform.position.z)
		;

		
	}

	void MovenonSeamlessBG()
    {
		
		transform.position -= Vector3.right * Time.deltaTime * scrollSpeed;

		if (scrollSpeed > 0) // going left
		{
			if (transform.position.x < -nonSeamlessTravelWidth)
			{
				transform.position = new Vector3(nonSeamlessTravelWidth, transform.position.y, transform.position.z);
			}
		}
		else
		{
			if (transform.position.x > nonSeamlessTravelWidth)
			{
				transform.position = new Vector3(-nonSeamlessTravelWidth, transform.position.y, transform.position.z);
			}
		}
		
	}
}
