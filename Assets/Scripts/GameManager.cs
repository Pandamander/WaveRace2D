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
Fix the trophy when you land on head
Add button to go back to level unlock
Secret back of the level area
Random flip text
Don't fall off the edge
Tune the levels
 
NEXT UP:


Add trophy collector on level screen
Link to Twitter



Make 3 levels with differnet color


SFX from https://opengameart.org/content/nes-8-bit-sound-effects
Music by: 

Bugs:
Have the camera reset when you reset
Have the timer start when you start




can finish line after dying


Have it say NICE! when you flip


P2 level structure:
Let you pick different levels, try to get gold in all of them








 */