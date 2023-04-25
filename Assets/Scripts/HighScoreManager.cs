using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private List<int> highScores = new List<int>();

    private void Start()
    {
        // Load the high scores from PlayerPrefs
        for (int i = 1; i <= 3; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }

        // Update the high score text
        UpdateHighScoreText();
    }

    private void UpdateHighScoreText()
    {
        string text = "High Score\n";
        for (int i = 0; i < highScores.Count; i++)
        {
            text += (i + 1) + ". " + highScores[i] + "\n";
        }
        highScoreText.text = text;
    }

    public void AddScoreToHighScores(int score)
    {
        // Add the score to the high scores list and sort it
        highScores.Add(score);
        highScores.Sort();
        highScores.Reverse();

        // Truncate the list to the top three scores
        if (highScores.Count > 3)
        {
            highScores.RemoveRange(3, highScores.Count - 3);
        }

        // Save the high scores to PlayerPrefs
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + (i + 1), highScores[i]);
        }

        // Update the high score text
        UpdateHighScoreText();
    }
}