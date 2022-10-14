using UnityEngine;
using TMPro; // Required for TextMeshPro UI
// using UnityEngine.UI; In the end we didn't use this here

// This script is more like a ScoreUpdater than Dice.. probably best to rename..
public class Dice : MonoBehaviour
{

    public TextMeshProUGUI scoreText; // Replaces Text variable used in tutorial
    public TextMeshProUGUI highScoreText;

    // Probably a good idea to create variables for the scores themselves, not just the text
    // These variables can then be fed into the method from other processes.
    // Can then create an UpdateScoreText method using the score floats

    // Could combine into one line eg
    // private float score, highScore;

    // But probably easier to read as..
    // private float score;
    // private float highScore;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore", 0).ToString();
    }

    public void RollDice()
    {
        int _randomNumber = Random.Range(1, 7); // Min# is INclusive, Max# is EXclusive
        scoreText.text = _randomNumber.ToString();

        if(_randomNumber > PlayerPrefs.GetInt("SavedHighScore", 0))
        {
            PlayerPrefs.SetInt("SavedHighScore", _randomNumber);
            highScoreText.text = _randomNumber.ToString();
        }
    }

    public void ResetHighScore()
    {
        // PlayerPrefs.DeleteAll; = Delete all saved data
        PlayerPrefs.DeleteKey("SavedHighScore"); // Delete High Score data only
        highScoreText.text = "0";
    }

}