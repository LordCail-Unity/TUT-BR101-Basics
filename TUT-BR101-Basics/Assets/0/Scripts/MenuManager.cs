using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public GameObject loadingScreenUI;
    public Slider _slider;
    public TMPro.TMP_Text progressText; 

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        loadingScreenUI.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            // Could do this to make the progress 100% at 90% but this will look weird.. better to hang at 90% for a while
            // float progress = Mathf.Clamp01(operation.progress / 0.9f);
            float progress = operation.progress;
            Debug.Log(progress);

            _slider.value = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            Debug.Log(progressText.text);

            yield return null;
        }
    }

}
