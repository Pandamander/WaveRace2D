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
Make the power meter into a visual meter
Make it so that hitting acceleration is what uses it up, not a timer





NEXT UP:
Level structure:
Have it say ready set GO and then timer starts
- Press L to go to level select
- Store the medal in a instanced object


Gameplay:
Make a timer to get to the finish line that counts down
Make checkpoints that give you more time

Have it say NICE! when you flip


P2 level structure:
Let you pick different levels, try to get gold in all of them

P2 gameplay
Have you get style points


Visuals:
Look up unity trails, see how those work, enable when you are going fast










 */