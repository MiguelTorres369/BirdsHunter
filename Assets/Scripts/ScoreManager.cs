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
        score = 0;
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
}