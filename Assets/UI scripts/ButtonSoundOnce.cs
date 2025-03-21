using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSoundOnce : MonoBehaviour
{
    public AudioSource audioSource; // Assign your AudioSource in the Inspector
    private bool hasPlayed = false; // Tracks if the sound has been played

    private void OnMouseDown()
    {
        if (!hasPlayed)
        {
            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayed = true; // Prevents the sound from playing again
                Debug.Log("Sound played once.");
            }
            else
            {
                Debug.LogError("AudioSource not assigned!");
            }
        }
        else
        {
            Debug.Log("Sound already played.");
        }
    }

    // Optional: Reset the state if needed
    public void ResetSound()
    {
        hasPlayed = false;
        Debug.Log("Sound reset.");
    }
}

