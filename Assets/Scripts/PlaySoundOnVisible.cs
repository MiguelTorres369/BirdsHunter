using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnVisible : MonoBehaviour
{
    public AudioClip audioClip;
    public float volume = 1.0f;

    private bool isPlaying = false;
    private AudioSource audioSource;
    private Camera mainCamera;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = true;

        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!isPlaying && IsVisibleOnScreen())
        {
            audioSource.Play();
            isPlaying = true;
        }
        else if (isPlaying && !IsVisibleOnScreen())
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }

    private bool IsVisibleOnScreen()
    {
        if (mainCamera == null)
        {
            return false;
        }

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        Collider collider = GetComponent<Collider>();
        if (collider == null)
        {
            return false;
        }
        return GeometryUtility.TestPlanesAABB(planes, collider.bounds);
    }
}
