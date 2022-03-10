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
Make it so that it can detect in air vs on ground
Then make it so in air forward means dive
Then make it so when you restart it turns you right side up



NEXT UP:
Make the water repeat forever
Make it restart you automatically
Zero out the torque when you restart
Then, zero out torque when you rotate back. It feels back to release left arrow and then start rotating forwards again
Add in a animation for when you are diving to indicate it

 */