using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public GameObject startScreenUI;
    public GameObject levelRestartUI;
    public GameObject levelCompleteUI;
    public GameObject loadingScreenUI;
    public LoadingSlider _loadingScreenUI;
    public int sceneIndexToLoad; // Set if required or leave at 0 and load next scene in build index

    private IEnumerator _coroutine; // Need this for the Delay part of the script
    private float screenDelaySecs = 2f;

    public void StartGame()
    {
        startScreenUI.SetActive(false);
        LoadLevel();
    }

    public void LoadLevel()
    {
        var sceneIndex = 0;
        Debug.Log("SceneToLoadIndex:" + sceneIndexToLoad);

        loadingScreenUI.SetActive(true);

        // How to activate unloading scene correctly?
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("currentSceneIndex:" + currentSceneIndex);
        if(currentSceneIndex != 0)
        {
            SceneManager.UnloadSceneAsync(currentSceneIndex);
            Debug.Log("UnloadAsync completed");
        }
        // How to activate unloading scene correctly?

        if (sceneIndexToLoad == 0)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            sceneIndex = sceneIndexToLoad;
        }

        Debug.Log("SceneIndex:" + sceneIndex);
        StartCoroutine(LoadAsynchronously(sceneIndex));

        levelCompleteUI.SetActive(false);
        levelRestartUI.SetActive(false);
        loadingScreenUI.SetActive(false);

    }

    public void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETE CALLED");
        sceneIndexToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("SceneToLoadIndex:" + sceneIndexToLoad);

        _coroutine = OnComplete(screenDelaySecs);
        StartCoroutine(_coroutine);
    }

    public void RestartLevel()
    {
        Debug.Log("RESTART LEVEL CALLED");
        sceneIndexToLoad = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("SceneToLoadIndex:" + sceneIndexToLoad);

        _coroutine = OnRestart(screenDelaySecs);
        StartCoroutine(_coroutine);
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
        LoadLevel();

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
        LoadLevel();

        Debug.Log("OnComplete COROUTINE COMPLETED");

    }


    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        Debug.Log("Async Loading Started");

        while (!operation.isDone)
        {

            float progress = operation.progress;
            Debug.Log(progress);

            _loadingScreenUI.UpdateSlider(progress);

            yield return null;
        }

        Debug.Log("Async Loading Completed");

    }

}


