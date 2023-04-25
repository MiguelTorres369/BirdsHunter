using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    private void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public int SaveScore()
{
    int bestScore1 = PlayerPrefs.GetInt("BestScore1", 0);
    int bestScore2 = PlayerPrefs.GetInt("BestScore2", 0);
    int bestScore3 = PlayerPrefs.GetInt("BestScore3", 0);
    int savedScore = 0;

    if (score > bestScore1)
    {
        PlayerPrefs.SetInt("BestScore3", bestScore2);
        PlayerPrefs.SetInt("BestScore2", bestScore1);
        PlayerPrefs.SetInt("BestScore1", score);
        savedScore = score;
    }
    else if (score > bestScore2)
    {
        PlayerPrefs.SetInt("BestScore3", bestScore2);
        PlayerPrefs.SetInt("BestScore2", score);
        savedScore = score;
    }
    else if (score > bestScore3)
    {
        PlayerPrefs.SetInt("BestScore3", score);
        savedScore = score;
    }

    PlayerPrefs.Save();

    return savedScore;
}

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public void SaveCurrentScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
