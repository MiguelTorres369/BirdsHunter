using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private int highScore;

    private void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore");

        // Load the latest score from ScoreManager and check if it's a new high score
        int latestScore = ScoreManager.Instance.SaveCurrentScore();
        if (latestScore > highScore)
        {
            highScore = latestScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // Update the high score text
        AddScoreToHighScores(highScore);
    }

    public void AddScoreToHighScores(int score)
    {
        highScoreText.text = "High Score: " + highScore;
    }
}