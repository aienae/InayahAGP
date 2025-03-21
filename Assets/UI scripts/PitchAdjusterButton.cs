using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchAdjusterButton : MonoBehaviour
{

    public AudioSource audioSource; 
    public float minPitch = 0.8f;   
    public float maxPitch = 1.2f;   

    private void OnMouseDown()
    {
        if (audioSource != null)
        {
            float randomPitch = Random.Range(minPitch, maxPitch);
            audioSource.pitch = randomPitch;

            audioSource.Play(); // play w adjusted pitch
        }
        else
        {
            Debug.LogError("AudioSource is not assigned");
        }
    }
}
