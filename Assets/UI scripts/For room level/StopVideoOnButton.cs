using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StopVideoOnButton : MonoBehaviour
{
    public VideoPlayer videoPlayerrr;
    public GameObject videoPlayerCanvass;
    
    private void OnMouseDown()
    {
        if (!videoPlayerrr.isPlaying)
        {
            videoPlayerrr.Stop();
            videoPlayerCanvass.SetActive(false);
            Debug.Log("video stopped");
        }
        else
        {
              Debug.Log("no video is play");  
        }
    }
}
