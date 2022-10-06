using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    
    public Slider _slider;
    public TMPro.TMP_Text progressText;

    private int progress;

    public void UpdateSlider(float progress)
    {
        _slider.value = progress;
        progressText.text = Mathf.Round(progress * 100f) + "%";
        Debug.Log(progressText.text);
    }

}
