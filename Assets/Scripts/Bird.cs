using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float speed = 5f;
    public int pointValue = 100;
    public Animator strikeAnim;

    private Camera mainCamera;
    private ScoreManager scoreManager;
    private HighScoreManager highScore;
    [SerializeField] private ParticleSystem birdExpolision = default;

    private float randomXDirection;
    private float randomYDirection;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        highScore = FindObjectOfType<HighScoreManager>();
        strikeAnim = GetComponent<Animator>();
        mainCamera = Camera.main;

        // Set a random initial position within the camera view
        float randomY = Random.Range(0.1f, 0.9f);
        float randomX = Random.Range(0.1f, 0.9f);
        Vector3 randomPos = mainCamera.ViewportToWorldPoint(new Vector3(randomX, randomY, 10f));
        transform.position = randomPos;

        // Set a random direction
        randomXDirection = Random.Range(-1f, 1f);
        randomYDirection = Random.Range(-1f, 1f);
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(randomXDirection);
        transform.localScale = scale;

        // Destroy the bird after 6 seconds
        Destroy(gameObject, 6f);

    }

    private void Update()
    {
        // Move the bird randomly
        Vector2 movement = new Vector2(randomXDirection, randomYDirection) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Change direction if bird goes off-screen
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPos.x < 0f || screenPos.x > 1f)
        {
            randomXDirection *= -1f;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(randomXDirection);
            transform.localScale = scale;
        }

        if (screenPos.y < 0f || screenPos.y > 1f)
        {
            randomYDirection *= -1f;
        }

        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPos = Input.GetTouch(0).position;
            touchPos.z = 10f; // Set the touch position at the same depth as the bird
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPos);

            // Check if the touch position intersects with the bird's collider
            if (GetComponent<Collider2D>().OverlapPoint(worldPos))
            {
                try
                {
                    if (scoreManager != null)
                    {
                        strikeAnim.Play("Strike");
                        birdExpolision.Play();
                        scoreManager.AddScore(pointValue);

                        if (highScore != null)
                        {
                            highScore.AddScoreToHighScores(scoreManager.SaveCurrentScore());
                        }

                        Destroy(gameObject, 0.3f);
                    }
                }
                    catch (System.NullReferenceException ex)
                    {
                        Debug.LogError("Error: " + ex.Message);
                    }
            }
        }
    }

   public void OnMouseDown()
{
    try
    {
        if (scoreManager != null)
        {
            strikeAnim.Play("Strike");
            birdExpolision.Play();
            scoreManager.AddScore(pointValue);

            if (highScore != null)
            {
                highScore.AddScoreToHighScores(scoreManager.SaveCurrentScore());
            }

            Destroy(gameObject, 0.3f);
        }
    }
    catch (System.NullReferenceException ex)
    {
        Debug.LogError("Error: " + ex.Message);
    }
}
}