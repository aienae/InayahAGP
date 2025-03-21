using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class puzzle1VidEnd : MonoBehaviour
{
    public GameObject videoGameObject; // The GameObject that plays the video
    private VideoPlayer videoPlayer; 
    public GameObject puzzle1Page;
    public GameObject puzzle1Canvas;
    public GameObject decryptButton;

    void Start()
    {
        // Get the VideoPlayer component attached to the GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer == null)
        {
            return;
        }

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video finished playing. Hiding GameObject.");
        videoGameObject.SetActive(false); // Hide the GameObject
        puzzle1Canvas.SetActive(true);
        puzzle1Page.SetActive(true);
        decryptButton.SetActive(false);    
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd; // Unsubscribe to prevent memory leaks
        }
    }
}

