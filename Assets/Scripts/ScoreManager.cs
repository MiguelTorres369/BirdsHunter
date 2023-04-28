using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private static ScoreManager instance;

    public static ScoreManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

        public void StartNewGame()
    {
        // Clear the PlayerPrefs to reset the score
        PlayerPrefs.DeleteKey("Score");

        // Load the scene for the new game
        SceneManager.LoadScene("Level001");
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        SaveCurrentScore();
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("HighScore");
    }

    public int SaveCurrentScore()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            return score;
        }
        else
        {
            return currentHighScore;
        }
    }
}