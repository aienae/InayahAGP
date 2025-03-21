using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HideAllVideos : MonoBehaviour
{
    public GameObject[] videoCanvases;
    public VideoPlayer[] videoPlayers;

    private bool[] wasVideoPlaying;

    private void Start()
    {
        wasVideoPlaying = new bool[videoPlayers.Length];
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < videoPlayers.Length; i++)
        {
            if (videoPlayers[i] != null)
            {
                wasVideoPlaying[i] = videoPlayers[i].isPlaying; // Record playback state
                videoPlayers[i].Pause(); // Pause the video
                Debug.Log($"Video '{videoPlayers[i].name}' was {(wasVideoPlaying[i] ? "playing" : "paused")}.");
            }

            if (videoCanvases[i] != null)
            {
                videoCanvases[i].SetActive(false); // Hide canvas
                Debug.Log($"Hid canvas: {videoCanvases[i].name}");
            }
        }
    }

    public bool[] GetPlaybackStates()
    {
        return wasVideoPlaying;
    }
}





