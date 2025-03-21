using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CloseVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Reference to the VideoPlayer
    public RawImage videoDisplay;    // Reference to the Raw Image displaying the video
    public GameObject videoCanvas;

    private void OnMouseDown()
    {
    if (videoPlayer != null && videoDisplay != null)
        {
            videoPlayer.Stop();
            //videoDisplay.texture = null; // Clear the Raw Image texture
            videoCanvas.SetActive(false);
        }
    }
}

