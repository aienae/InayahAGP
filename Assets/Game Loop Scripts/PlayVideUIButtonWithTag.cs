using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideUIButtonWithTag : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private Canvas canvas;

    private bool isMouseOverPrefab = false;

public void Initialize(VideoPlayer assignedVideoPlayer, Canvas assignedCanvas)
{
    videoPlayer = assignedVideoPlayer;
    canvas = assignedCanvas;

    if (videoPlayer == null || canvas == null)
    {
        Debug.LogError("VideoPlayer or Canvas not initialized!");
    }
    else
    {
        if (videoPlayer.isPlaying)
        {
            canvas.gameObject.SetActive(true);
            Debug.Log($"{canvas.name} is active because a video is already playing.");
        }
        else
        {
            canvas.gameObject.SetActive(false); // Ensure canvas stays hidden unless clicked
            Debug.Log($"{canvas.name} is hidden on initialization.");
        }
    }
}



    private void OnMouseDown()
    {
        if (videoPlayer != null && canvas != null)
        {
            canvas.gameObject.SetActive(true);
            videoPlayer.Play();
            Debug.Log("Playing video on the correct canvas!");
        }
        else
        {
            Debug.LogError("VideoPlayer or Canvas is missing during playback!");
        }
    }

    private void OnMouseOver()
    {
        isMouseOverPrefab = true;
    }

    private void OnMouseExit()
    {
        isMouseOverPrefab = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMouseOverPrefab)
        {
            if (videoPlayer != null && canvas != null && canvas.gameObject.activeSelf)
            {
                //videoPlayer.Stop();
                //canvas.gameObject.SetActive(false);
                //Debug.Log("Stopped video and hid canvas.");
            }
        }
    }
}








