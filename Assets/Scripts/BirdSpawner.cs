using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;


public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;

    public float spawnInterval = 2f;

    private Camera mainCamera;
    private float cameraWidth;
    private float cameraHeight;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = cameraWidth / cameraHeight;

        if (screenRatio >= targetRatio)
        {
            mainCamera.orthographicSize = cameraHeight / 2f;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            mainCamera.orthographicSize = cameraHeight / 2f * differenceInSize;
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnBird", 0f, spawnInterval);
    }

    private void SpawnBird()
    {
        Vector3 spawnPosition = new Vector3(0f, Random.Range(-cameraHeight / 2f, cameraHeight / 2f), 0f);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(birdPrefab, spawnPosition, spawnRotation);
    }
}