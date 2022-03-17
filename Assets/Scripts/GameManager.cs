using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // quit the game
            Application.Quit();
        }
        
    }


}




/*
 * 
 * 

DONE:
Make the power bar into balls



NEXT UP:
Gameplay:

The power should go back down???? It's like a boost you get from flipping!
Have it say NICE! when you flip

Level structure:
Have it say ready set GO and then timer starts
Have it give you a medal at the end based on your time


P2 level structure:
Let you pick different levels, try to get gold in all of them

P2 gameplay
Have you get style points


Visuals:
Do Cooper's sprites
Look up unity trails, see how those work, enable when you are going fast










 */