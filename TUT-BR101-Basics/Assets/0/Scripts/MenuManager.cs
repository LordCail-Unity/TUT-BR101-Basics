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

            float progress = operation.progress;
            Debug.Log(progress);

            _slider.value = progress;
            progressText.text = Mathf.Round(progress * 100f) + "%";
            Debug.Log(progressText.text);

            yield return null;
        }
    }

}

// NOTE
// Unity cuts loading operation at 90% to do other stuff
// Could do Math to make the displayed progress = 100% at 90%..
// float progress = Mathf.Clamp01(operation.progress / 0.9f);
// BUT this looks weird if other stuff takes a while..
// Better to hang at 90% for a while
