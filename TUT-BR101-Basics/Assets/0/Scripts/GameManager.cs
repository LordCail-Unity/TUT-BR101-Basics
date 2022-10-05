using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LevelManager _levelManager;

    bool restartLevel = false;
    bool levelComplete = false;

    public GameObject levelRestartUI;
    public GameObject levelCompleteUI;

    private IEnumerator _coroutine;
    public float delaySecs = 2f;

    // NOTE: Because they are almost exactly the same script,
    // we could collapse (refactor) these two functions into a single function
    // using the boolean variables to specify which parts of the function to call
    // however it is probably easier to read like this.

    public void LevelComplete ()
    {
        if (levelComplete == false)
        {
            levelComplete = true;
            Debug.Log("LEVEL COMPLETED");
            _coroutine = OnComplete(delaySecs);
            StartCoroutine(_coroutine);
        }
    }

    public void RestartLevel ()
    {
        if (restartLevel == false)
        {
            restartLevel = true;
            Debug.Log("RESTART LEVEL");
            _coroutine = OnRestart(delaySecs);
            StartCoroutine(_coroutine);
        }
    }

    IEnumerator OnRestart(float delaySecs)
    {
        Debug.Log("OnRestart COROUTINE STARTED");
        
        //wait for delay seconds
        yield return new WaitForSecondsRealtime(delaySecs);

        //do stuff
        levelRestartUI.SetActive(true);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("OnRestart ACTION CALLED");
        _levelManager.ReloadCurrentLevel();
        Debug.Log("OnRestart COROUTINE COMPLETED");

    }

    IEnumerator OnComplete(float delaySecs)
    {
        Debug.Log("OnComplete COROUTINE STARTED");

        //wait for delay seconds
        yield return new WaitForSecondsRealtime(delaySecs);

        //do stuff
        levelCompleteUI.SetActive(true);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("LEVEL COMPLETE ACTION CALLED");
        _levelManager.LoadNextLevel();

        Debug.Log("OnComplete COROUTINE COMPLETED");

    }

}
