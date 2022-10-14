using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    // Probably better to have AsyncLoad and AsyncUnload in LevelManager but 
    // Loading Slider and AsyncLoad are easiest to set up in the same script
    // Because. Reasons.

    public Slider _slider;
    public TMPro.TMP_Text progressText;

    public float loadingUIDelaySecs = 0.1f; // Loading screen is too fast to see so tiny delay.

    private int progress;

    public void Awake()
    {
        _slider = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponentInChildren<Slider>();
    }

    public void UpdateSlider(float progress)
    {
        _slider.value = progress;
        progressText.text = Mathf.Round(progress * 100f) + "%";
        Debug.Log(progressText.text);
    }


    public void StartAsyncLoadCoroutine(int sceneIndex)
    {
        int sceneToLoad = sceneIndex;
        StartCoroutine(AsyncLoad(sceneToLoad, loadingUIDelaySecs));
    }

    IEnumerator AsyncLoad(int sceneIndex, float delaySecs)
    {

        yield return new WaitForSecondsRealtime(delaySecs);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        Debug.Log("Async Loading Started");

        while (!operation.isDone)
        {

            float progress = operation.progress;
            Debug.Log(progress);

            UpdateSlider(progress);

            yield return null;
        }

        Debug.Log("AsyncLoad completed | SceneIndex:" + sceneIndex);

        yield return new WaitForSecondsRealtime(delaySecs);

        UpdateSlider(1f);
        //Gives the effect of 100% completion just before starting the round
        //Could use DOTween to smooth this but surely we have better things to work on (>_<)

        yield return new WaitForSecondsRealtime(delaySecs);

        FindObjectOfType<LevelManager>().DestroyLoadingScreen();

    }

}
