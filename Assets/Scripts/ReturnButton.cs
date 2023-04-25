using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    private float touchTime;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - touchTime > 3f)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }
    }
}