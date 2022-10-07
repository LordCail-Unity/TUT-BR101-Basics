using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // public LevelManager _levelManager;
    // Replaced by FindObjectOfType below
    // FindObjectOfType required to allow for Additive Loading?

    private bool levelRestart;
    private bool levelComplete;


    public void Crashed()
    {
        levelRestart = true;
        Debug.Log("GAMEMANAGER: PLAYER HIT OBJECT");

        // _levelManager.RestartLevel();
        // Replaced by FindObjectOfType 

        if (levelRestart == true)
        {
            FindObjectOfType<LevelManager>().LevelRestart();
            levelRestart = false;
        }

    }

    public void FellToDeath()
    {
        levelRestart = true;
        Debug.Log("GAMEMANAGER: PLAYER FELL BELOW KILLZONE");

        // _levelManager.RestartLevel();
        // Replaced by FindObjectOfType 

        // BUG!! Loading multiple instances of the scene when falling through killzone
        // Because LevelRestart uses AsyncLoading you can get multiple collisions before completing.
        // There should be a boolean trick seems to fix that issue well enough for now.
        if (levelRestart == true)
        {
            FindObjectOfType<LevelManager>().LevelRestart();
        }

    }

    public void LevelComplete()
    {
        levelComplete = true;
        Debug.Log("GAMEMANAGER: PLAYER TRIGGERED FINISH LINE");

        // _levelManager.LoadLevel();
        // Replaced by FindObjectOfType 

        // Because LevelComplete uses AsyncLoading you can get multiple collisions before completing.
        // This boolean trick seems to fix that issue well enough for now.
        if (levelComplete == true)
        {
            FindObjectOfType<LevelManager>().LevelComplete();
            levelComplete = false;
        }
    }

}
