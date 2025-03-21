using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class bubble6Script : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign in the Inspector
    private bool hasExecuted = false; // Ensures code runs only once
    public GameObject bubblePrefab; // bubble 6

    // this script can be found on the laugh video empty, the creates bubble 6 when they video finishes
    
    private void Start()
    {
        if (videoPlayer != null)
        {
            // Subscribe to the loopPointReached event
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned!");
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (!hasExecuted)
        {
            ExecuteCode();
            hasExecuted = true;
        }
    }

    private void ExecuteCode()
    {
        BubbleManager.Instance.CreateBubble(bubblePrefab); // create bubble 6 when video ends
        FindObjectOfType<Casette>().RegisterInstantiatedObject(bubblePrefab); // adds it to casette script
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            // Unsubscribe to prevent memory leaks
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}

