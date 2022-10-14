using UnityEngine;
using TMPro; // Required for TextMeshPro UI
// using UnityEngine.UI; In the end we didn't use UnityEngine.UI here


// This script is meant to replace Brackey's original Dice script.
// Because it is more like a ScoreUpdater than Dice we have renamed it.
// It can also be ported into simple games (eg Brackey's Cubethon) with a few tweaks.
// In that case the script could be called simply ScoreUpdater or similar.

public class DiceScoreUpdater : MonoBehaviour
{
    // Much more effective to create variables for the scores themselves, not just the text
    // These variables can then be fed into the method from other processes.
    // Can then create an UpdateScoreText method using the score variables

    private int score = 0;
    private int highScore = 0;

    public TextMeshProUGUI scoreText; // Replaces Text variable used in tutorial
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("SavedHighScore", highScore); // Get HighScore from data or set to default 0
        UpdateScoreText();
    }

    public void UpdateScore()  // Public because called by a UI button but could be called by another method eg from Main Menu
    {
        GetScore();
        CheckHighScore();
        UpdateScoreText();
    }

    private void GetScore()
    {
        // Generate a random "score".
        // This can easily be replaced by a method to get the score another way.
        // Random.Range(Min# is INclusive, Max# is EXclusive)
        int _randomNumber = Random.Range(1, 7); 
        score = _randomNumber;
    }

    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("SavedHighScore", highScore);
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    public void ResetHighScore() // Public because called by a UI button
    {
        // [OPTIONAL] PlayerPrefs.DeleteAll; = Delete ALL saved data

        PlayerPrefs.DeleteKey("SavedHighScore"); // Delete High Score data ONLY
        highScore = 0;
        UpdateScoreText();
    }

}