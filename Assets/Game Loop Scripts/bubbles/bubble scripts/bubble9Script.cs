using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble9Script : MonoBehaviour
{
    private bool hasExecuted = false;
    public GameObject bubblePrefab;
    public GameObject casetteCloseUpPrefab;

    public static GameObject instantiatedCasette;  // static reference of the cassette that was instantiated to access it in another script

    private void OnMouseDown()
    {
        if (!hasExecuted)
        {
            // First click: Instantiate objects and play the video
            BubbleManager.Instance.CreateBubble(bubblePrefab);

            // Instantiate the cassette prefab
            Vector3 customPosition = new Vector3(578f, 325f, 0f);  // X, Y, Z position
            Quaternion customRotation = Quaternion.Euler(0f, 0f, 11.9f);  // Rotation (X, Y, Z in degrees)
            Vector3 customScale = new Vector3(220f, 220f, 204f);  // Scale (X, Y, Z)

            // Instantiate the cassette
            instantiatedCasette = Instantiate(casetteCloseUpPrefab, customPosition, customRotation);

            hasExecuted = true;
        }
        else
        {
            // On subsequent clicks: Stop the video, reset it, and play the video
            if (PlayCassette.Instance.videoPlayerr.isPlaying)
            {
                PlayCassette.Instance.videoPlayerr.Stop();  // Stop the video if it's playing
            }

            // Reset to the beginning
            PlayCassette.Instance.videoPlayerr.time = 0;

            // Ensure the canvas is active
            PlayCassette.Instance.videoPlayerCanvas.SetActive(true);

            // Play the video again
            PlayCassette.Instance.videoPlayerr.Play();
        }
    }
}

