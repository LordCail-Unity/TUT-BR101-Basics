using UnityEngine;
using TMPro; // Required for TextMeshPro UI
// using UnityEngine.UI; In the end we didn't use UnityEngine.UI here

// Based on Brackey's High Score Tutorial > Dice script
// Because it is more like a ScoreUpdater than Dice we have renamed it.
// This version has been designed to integrate into Brackey's Cubethon.

public class ScoreUpdater : MonoBehaviour
{
    // Much more effective to create variables for the scores themselves, not just the text
    // These variables can then be fed into the method from other processes.
    // Can then create an UpdateScoreText method using the score variables

    GameObject player;

    private int score = 0;
    private int highScore = 0;

    public TextMeshProUGUI scoreText; // Replaces Text variable used in tutorial
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        highScore = PlayerPrefs.GetInt("SavedHighScore", highScore); // Get HighScore from data or set to default 0
        UpdateScoreText();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore() 
    {
        GetScore();
        CheckHighScore();
        UpdateScoreText();
    }

    private void GetScore()
    {
        score = Mathf.FloorToInt(player.transform.position.z);
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

    // ADD A BUTTON TO MAIN MENU TO RESET SCORE

    public void ResetHighScore() // Public because called by a UI button 
    {
        // [OPTIONAL] PlayerPrefs.DeleteAll; = Delete ALL saved data

        PlayerPrefs.DeleteKey("SavedHighScore"); // Delete High Score data ONLY
        highScore = 0;
        UpdateScoreText();
    }

}