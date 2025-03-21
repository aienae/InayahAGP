using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVidWhenGameObjButtonClick : MonoBehaviour
{
    public VideoPlayer videoPlayerr;
    public GameObject videoPlayerCanvas;
    
    private void OnMouseDown()
    {
        if (videoPlayerr != null)
        {
            if (!videoPlayerr.isPlaying)
            {
                videoPlayerr.Play();
                videoPlayerCanvas.SetActive(true);
            }
            else
            {
                
            }
        }
        else
        {
            Debug.LogWarning("No VideoPlayer assigned!");
        }
    }
}  
