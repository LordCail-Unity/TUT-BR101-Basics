using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // public LevelManager _levelManager;
    // Replaced by FindObjectOfType below
    // FindObjectOfType required to allow for Additive Loading?

    private bool levelRestart = false;
    private bool levelComplete = false;


    public void Crashed()
    {
        levelRestart = true;
        Debug.Log("GAMEMANAGER: PLAYER HIT OBJECT");

        // _levelManager.RestartLevel();
        // Replaced by FindObjectOfType 

        FindObjectOfType<LevelManager>().RestartLevel();
        levelRestart = false;
    }

    public void FellToDeath()
    {
        levelRestart = true;
        Debug.Log("GAMEMANAGER: PLAYER FELL BELOW KILLZONE");

        // _levelManager.RestartLevel();
        // Replaced by FindObjectOfType 

        FindObjectOfType<LevelManager>().RestartLevel();
        levelRestart = false;
    }

    public void LevelComplete()
    {
        levelComplete = true;
        Debug.Log("GAMEMANAGER: PLAYER TRIGGERED FINISH LINE");

        // _levelManager.LoadLevel();
        // Replaced by FindObjectOfType 

        FindObjectOfType<LevelManager>().LevelComplete();
        levelComplete = false;
    }
}
