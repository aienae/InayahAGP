using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayCassette : MonoBehaviour
{
    public static PlayCassette Instance;
    public VideoPlayer videoPlayerr;
    public GameObject videoPlayerCanvas;
    public CanvasGroup blackFadeOverlay;

    // Flag to check if the video has ended
    public bool isVideoFinished { get; private set; } = false;  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (videoPlayerr != null)
        {
            videoPlayerr.loopPointReached += OnVideoEnd;
        }
    }

    public void playKidnapVCR()
    {
        if (videoPlayerr != null && !videoPlayerr.isPlaying)
        {
            videoPlayerr.Play();
            videoPlayerCanvas.SetActive(true);
            isVideoFinished = false; // Reset the flag when the video starts
        }
        else if (videoPlayerr == null)
        {
            Debug.LogWarning("No VideoPlayer assigned!");
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(FadeOutAndHide(1.5f));
        isVideoFinished = true;  // Set the flag to true when the video ends
    }

    private IEnumerator FadeOutAndHide(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            blackFadeOverlay.alpha = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }

        videoPlayerr.Stop();
        videoPlayerCanvas.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            blackFadeOverlay.alpha = Mathf.Clamp01(1 - (elapsedTime / duration));
            yield return null;
        }
    }
}


