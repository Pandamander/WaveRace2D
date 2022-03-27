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
Text highlights
Ending scores
Try 3 separate emitters
Mini map


Streak for when at full speed
Back tip of jetski shoots
Fall into the water when you

Stop wave movement
can finish line after dying


Gameplay:



Have it say NICE! when you flip


P2 level structure:
Let you pick different levels, try to get gold in all of them

P2 gameplay
Have you get style points


Visuals:
Look up unity trails, see how those work, enable when you are going fast



William Notes:
Checkpoint
Add in UI text
Course map

Spray from jetski
Ramps
Check

Not gonna do:
Excite Bike lanes
Multiple tricks






 */