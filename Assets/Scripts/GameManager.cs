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




NEXT UP:

Ending scores
Try 3 separate emitters - Come back to it
Mini map


Streak for when at full speed
Back tip of jetski shoots
Fall into the water when you


can finish line after dying


Have it say NICE! when you flip


P2 level structure:
Let you pick different levels, try to get gold in all of them








 */