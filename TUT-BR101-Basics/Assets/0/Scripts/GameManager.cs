using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool restartLevel = false;
    bool levelComplete = false;

    public GameObject levelRestartUI;
    public GameObject levelCompleteUI;
    public float delay = 2f;

    private IEnumerator _coroutine;

    public void LevelComplete ()
    {
        if (levelComplete == false)
        {
            levelComplete = true;
            Debug.Log("LEVEL COMPLETED");
            _coroutine = OnComplete(delay);
            StartCoroutine(_coroutine);
        }
    }

    public void RestartLevel ()
    {
        if (restartLevel == false)
        {
            restartLevel = true;
            Debug.Log("RESTART LEVEL");
            _coroutine = OnRestart(delay);
            StartCoroutine(_coroutine);
        }
    }

    IEnumerator OnRestart(float delay)
    {
        Debug.Log("OnRestart COROUTINE STARTED");
        
        //wait for delay seconds
        yield return new WaitForSecondsRealtime(delay);

        //do stuff
        levelRestartUI.SetActive(true);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("OnRestart ACTION CALLED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("OnRestart COROUTINE COMPLETED");

    }

    IEnumerator OnComplete(float delay)
    {
        Debug.Log("OnComplete COROUTINE STARTED");

        //wait for delay seconds
        yield return new WaitForSecondsRealtime(delay);

        //do stuff
        levelCompleteUI.SetActive(true);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("LEVEL COMPLETE ACTION CALLED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("OnComplete COROUTINE COMPLETED");

    }

}
