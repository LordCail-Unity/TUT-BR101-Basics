using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject startScreenUI;
    public GameObject levelRestartUI;
    public GameObject levelCompleteUI;
    public GameObject loadingScreenUI;
    public GameObject scoreDisplayUI;
    public GameObject endScreenUI;
    // REMOVE END GAME UI DUPLICATE -- Load on last level only
    // DESTROY SCOREUI AT END OF LEVEL

    private GameObject StartScreenUIInstance;
    private GameObject LoadingScreenUIInstance;
    private GameObject LevelRestartUIInstance;
    private GameObject LevelCompleteUIInstance;
    private GameObject scoreDisplayUIInstance;
    private GameObject endScreenUIInstance;


    public int sceneToLoad = 1; // Set if required or simply load next scene in build index
    private int currentScene = 1;


    private IEnumerator _coroutine; // Need this for the Delay part of the IEnumerator call?
    public float endLevelUIDelaySecs = 2f; // End level screens pop up too fast so long-ish delay.. 

    public void Start()
    {
        StartScreenUIInstance = Instantiate(startScreenUI);
    }

    public void StartGame()
    {
        Destroy(StartScreenUIInstance);
        LoadLevel();
    }

    public void LoadLevel()
    {
        InstantiateLoadingScreen();
        StartAsyncLoading();
        InstantiateHUDUI();
    }

    private void InstantiateHUDUI()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int finalSceneIndex = sceneCount - 1;
        // Scene.buildIndex varies from zero to the number of Scenes in the Build Settings minus one.
        if (currentScene < finalSceneIndex)
        {
            InstantiateScoreDisplayUI();
        }
        if (currentScene == finalSceneIndex)
        {
            InstantiateEndScreenUI();
        }
    }

    private void InstantiateScoreDisplayUI()
    {
        scoreDisplayUIInstance = Instantiate(scoreDisplayUI);
    }

    private void InstantiateEndScreenUI()
    {
        endScreenUIInstance = Instantiate(endScreenUI);
    }

    public void InstantiateLoadingScreen()
    {
        LoadingScreenUIInstance = Instantiate(loadingScreenUI);
        Debug.Log("currentScene:" + currentScene);
        Debug.Log("SceneToLoad:" + sceneToLoad);
        Debug.Log("Loading Screen Instantiated");
    }

    private void StartAsyncLoading()
    {
        FindObjectOfType<LevelLoader>().StartAsyncLoadCoroutine(sceneToLoad);
    }

    public void DestroyLoadingScreen()
    {
        Destroy(LoadingScreenUIInstance);
        Debug.Log("Loading Screen Instance Destroyed");

        currentScene = sceneToLoad;
        Debug.Log("Current Scene:" + currentScene);

        if (FindObjectOfType<PlayerMovement>() == true)
        {
            FindObjectOfType<PlayerMovement>().movePlayer = true;
        }
    }

    public void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETE CALLED");
        sceneToLoad = sceneToLoad + 1;
        Debug.Log("SceneToLoadIndex:" + sceneToLoad);

        _coroutine = OnComplete(endLevelUIDelaySecs);
        StartCoroutine(_coroutine);
    }

    public void LevelRestart()
    {
        Debug.Log("RESTART LEVEL CALLED");
        sceneToLoad = currentScene;
        Debug.Log("SceneToLoadIndex:" + sceneToLoad);

        _coroutine = OnRestart(endLevelUIDelaySecs);
        StartCoroutine(_coroutine);
    }

    IEnumerator OnRestart(float delaySecs)
    {
        Debug.Log("OnRestart COROUTINE STARTED");

        //wait for delay seconds
        yield return new WaitForSecondsRealtime(delaySecs);

        // After delaySecs, pull up the UI and unload the current scene
        LevelRestartUIInstance = Instantiate(levelRestartUI);

        StartCoroutine(AsyncUnload(currentScene));
        Debug.Log("UnloadAsync completed on SceneIndex:" + currentScene);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("OnRestart ACTION CALLED");

        Destroy(LevelRestartUIInstance);
        LoadLevel();

        Debug.Log("OnRestart COROUTINE COMPLETED");

    }

    IEnumerator OnComplete(float delaySecs)
    {
        Debug.Log("OnComplete COROUTINE STARTED");

        //wait for delay seconds
        yield return new WaitForSecondsRealtime(delaySecs);

        // Pull up the UI and unload the current scene
        LevelCompleteUIInstance = Instantiate(levelCompleteUI);

        StartCoroutine(AsyncUnload(currentScene));
        Debug.Log("UnloadAsync completed on SceneIndex:" + currentScene);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("LEVEL COMPLETE ACTION CALLED");

        Destroy(LevelCompleteUIInstance);
        LoadLevel();

        Debug.Log("OnComplete COROUTINE COMPLETED");

    }

    IEnumerator AsyncUnload(int sceneIndex)
    {
        sceneIndex = currentScene;
        Debug.Log("Async Unloading Operation Started");
        yield return null; 
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneIndex);
        Debug.Log("Async Unloading Operation Completed");

    }



}


