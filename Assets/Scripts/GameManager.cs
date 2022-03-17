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




NEEDED FOR DEMO:
Make a horizontal water, and small waves, more spaced out - DONE
Try out torque, and clamp the rotation speed if possible - DONE
Detect backflips - DONE
Have a flip increase your max speed - dONE
Have a simple text speed UI - DONE
Have it tell you press r to restart when you finish or when you fall over


Do Cooper's sprites


Forget about the tiny wings thing of catching the down wave. There's not enough time
It's just accelerate, jump, backflip





Make riding on the water, no ramps, feel good. Winning and losing

Make it restart you automatically
Zero out the torque when you restart
Then, zero out torque when you rotate back. It feels back to release left arrow and then start rotating forwards again
Add in a animation for when you are diving to indicate it
Feels bad to not be able to go up the ramp



 */