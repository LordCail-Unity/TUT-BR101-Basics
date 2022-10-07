using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UI; trying to use Canvas.ForceUpdateCanvases but broken.. :(

public class LevelManager : MonoBehaviour
{

    public Transform mainUI;

    public GameObject startScreenUI;
    public GameObject levelRestartUI;
    public GameObject levelCompleteUI;
    public GameObject loadingScreenUI;
    public LoadingSlider _loadingScreenUI;
    public int sceneToLoad = 1; // Set if required or simply load next scene in build index
    private int currentScene = 1;

    private IEnumerator _coroutine; // Need this for the Delay part of the IEnumerator call?
    public float endLevelUIDelaySecs = 2f; // End level screens pop up too fast so long-ish delay.. 
    public float loadingUIDelaySecs = 0.4f; // Loading screen is too fast to see so tiny delay..

    public void OnStartButtonClick()
    {
        loadingScreenUI.SetActive(true);
        startScreenUI.SetActive(false);
        LoadLevel();
    }

    public void LoadLevel()
    {
        Debug.Log("currentScene:" + currentScene);
        Debug.Log("SceneToLoad:" + sceneToLoad);

        // Trying to get canvas to update as it is getting glitchy after 2nd time displaying..
        // This method doesn't seem to work as the canvas no longer displays at all..
        // Could Destroy and Instantiate canvas prefabs but this seems inefficient and counterpurpose.
        // Could move canvas prefabs back to the levels but again it's undoing the point of having them in MainLevel.
        //
        // CanvasUpdate();

        loadingScreenUI.SetActive(true);
        levelCompleteUI.SetActive(false);
        levelRestartUI.SetActive(false);
        Debug.Log("Loading Screen Activated");

        StartCoroutine(AsyncLoad(sceneToLoad, loadingUIDelaySecs));
        currentScene = sceneToLoad;
        Debug.Log("Current Scene:" + currentScene);

    }

    // public static void CanvasUpdate () 
    // {
    //     Canvas.ForceUpdateCanvases();
    // }


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
        levelRestartUI.SetActive(true);
        StartCoroutine(AsyncUnload(currentScene));
        Debug.Log("UnloadAsync completed on SceneIndex:" + currentScene);

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

        // Pull up the UI and unload the current scene
        levelCompleteUI.SetActive(true);
        StartCoroutine(AsyncUnload(currentScene));
        Debug.Log("UnloadAsync completed on SceneIndex:" + currentScene);

        //wait for any key to be pressed
        yield return new WaitUntil(() => Input.anyKey);

        //do stuff when any key is pressed
        Debug.Log("LEVEL COMPLETE ACTION CALLED");
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


    IEnumerator AsyncLoad(int sceneIndex, float delaySecs)
    {

        Debug.Log("LoadScreen Wait Start");
        yield return new WaitForSecondsRealtime(delaySecs);
        Debug.Log("LoadScreen Wait End");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        Debug.Log("Async Loading Started");

        while (!operation.isDone)
        {

            float progress = operation.progress;
            Debug.Log(progress);

            _loadingScreenUI.UpdateSlider(progress);        

            yield return null;
        }

        Debug.Log("LoadScreen Wait Start");
        yield return new WaitForSecondsRealtime(delaySecs);
        Debug.Log("LoadScreen Wait End");

        _loadingScreenUI.UpdateSlider(1f);

        Debug.Log("LoadScreen Wait Start");
        yield return new WaitForSecondsRealtime(delaySecs);
        Debug.Log("LoadScreen Wait End");

        loadingScreenUI.SetActive(false);
        Debug.Log("Loading Screen Deactivated");
        Debug.Log("AsyncLoad completed | SceneIndex:" + sceneIndex);

        if(FindObjectOfType<PlayerMovement>() == true)
        {
            FindObjectOfType<PlayerMovement>().movePlayer = true;
        }

    }

}


