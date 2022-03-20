using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private string whichLevel;
    [SerializeField] private bool levelLocked;

    public void SelectNextLevel()
    {
        if (!levelLocked)
        {
            SceneManager.LoadScene(whichLevel); // load the level
        }
        else
        {
            Debug.Log("Level is locked!");
        }
            
    }

    public void UnlockLevel()
    {
        levelLocked = true;
    }

    public void LockLevel()
    {
        levelLocked = false;
    }
}
