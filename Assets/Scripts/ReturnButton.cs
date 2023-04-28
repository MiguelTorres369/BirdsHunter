using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ReturnButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float touchTime;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touchTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Time.time - touchTime > 1f)
        {
            scoreManager.SaveCurrentScore(); // Save the current score
            SceneManager.LoadScene("StartMenu");
        }
    }
}