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





NEXT UP:
Level structure:
Have it say ready set GO and then timer starts
- Press L to go to level select
- Store the medal in a instanced object

Make the level longer and more fun


Gameplay:
Have it say NICE! when you flip


P2 level structure:
Let you pick different levels, try to get gold in all of them

P2 gameplay
Have you get style points


Visuals:
Do Cooper's sprites
Look up unity trails, see how those work, enable when you are going fast










 */