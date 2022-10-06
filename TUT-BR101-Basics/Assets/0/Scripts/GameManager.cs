using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // public LevelManager _levelManager;
    // Replaced by FindObjectOfType below
    // FindObjectOfType required to allow for Additive Loading?

    public void Crashed()
    {
        Debug.Log("CRASHED");

        // _levelManager.RestartLevel();
        // Replaced by FindObjectOfType 

        FindObjectOfType<LevelManager>().RestartLevel();
    }

    public void FellToDeath()
    {
        Debug.Log("FELL BELOW KILLZONE");

        // _levelManager.RestartLevel();
        // Replaced by FindObjectOfType 

        FindObjectOfType<LevelManager>().RestartLevel();
    }

    public void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETED");

        // _levelManager.LoadLevel();
        // Replaced by FindObjectOfType 

        FindObjectOfType<LevelManager>().LevelComplete();
    }
}
