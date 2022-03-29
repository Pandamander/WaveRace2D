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
Text highlights: Flip, checkpoint
Try 3 separate emitters - Come back to it
Better looking title and level select
SFX


 SFX from https://opengameart.org/content/nes-8-bit-sound-effects
NEXT UP:
Make trophy different depending on ending score
Make 3 levels with differnet color
Tune the levels
Ending scores
Add SFX
Add finish line sprite
Add button to go back to level unlock



Bugs:
Have the timer start when you start


P2:
Show trophies earned 
Streak for when at full speed
Mini map
Back tip of jetski shoots
Fall into the water when you


can finish line after dying


Have it say NICE! when you flip


P2 level structure:
Let you pick different levels, try to get gold in all of them








 */