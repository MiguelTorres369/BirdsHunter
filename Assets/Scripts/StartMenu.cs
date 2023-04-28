using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnEnable()
    {
        // Retrieve the high score from PlayerPrefs and update the UI text
        int highScore = PlayerPrefs.GetInt("Score");
        highScoreText.text = highScore.ToString();
    }

    private void OnDisable()
    {
        // Save the current score to PlayerPrefs when returning to the start menu
        scoreManager.SaveCurrentScore();
    }
}