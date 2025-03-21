using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HideVidAfterDone : MonoBehaviour
{
    public VideoPlayer videoPlayer;   
    public GameObject rawImageObject; 

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (rawImageObject != null)
        {
            rawImageObject.SetActive(false); 
            Debug.Log("Video ended and Raw Image hidden.");
        }
    }
}
