using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class StopVideoByUI : MonoBehaviour, IPointerClickHandler
{
    public VideoPlayer videoPlayer;
    public GameObject videoPlayerCanvass;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the VideoPlayer is assigned!!!!
        if (videoPlayer != null)
        {
            // Stop the video and hide the canvas regardless if its playing !!
            videoPlayer.Stop();
            videoPlayerCanvass.SetActive(false);
            Debug.Log("Video stopped or canvas hidden!");
        }
        else
        {
            Debug.LogWarning("VideoPlayer is not assigned!");
        }
    }
}


