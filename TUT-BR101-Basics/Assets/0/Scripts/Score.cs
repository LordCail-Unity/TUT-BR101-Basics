using UnityEngine;
using UnityEngine.UI;
using TMPro; // Required for TextMeshPro GUI

public class Score : MonoBehaviour
{

    public Transform player;
    public TextMeshProUGUI scoreText; // TextMeshPro variant

    private void Update()
    {
        scoreText.SetText(player.position.z.ToString("0")); // TMP formatting does NOT use "=" formula; "0" removes decimal places.
    }

}