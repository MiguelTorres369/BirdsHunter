using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public Image backgroundImage;
    public float transitionTime = 1.0f;
    public Sprite[] backgrounds;
    private int currentIndex = 0;

    private IEnumerator ChangeBackground()
    {
        float t = 0;
        Color originalColor = backgroundImage.color;
        Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            backgroundImage.color = Color.Lerp(originalColor, newColor, t / transitionTime);
            yield return null;
        }

        currentIndex = (currentIndex + 1) % backgrounds.Length;
        backgroundImage.sprite = backgrounds[currentIndex];

        t = 0;
        originalColor = newColor;
        newColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1);
        while (t < transitionTime)
        {
            t += Time.deltaTime;
            backgroundImage.color = Color.Lerp(originalColor, newColor, t / transitionTime);
            yield return null;
        }

        yield return new WaitForSeconds(5.0f);
        StartCoroutine(ChangeBackground());
    }

    void Start()
    {
            if (backgrounds == null || backgrounds.Length == 0)
    {
        Debug.LogError("Backgrounds array is empty or null!");
        return;
    }

    backgroundImage.sprite = backgrounds[0];
    backgroundImage.color = new Color(1, 1, 1, 1);
    backgroundImage.gameObject.GetComponent<Canvas>().sortingOrder = -10;

    StartCoroutine(ChangeBackground());
    }
}