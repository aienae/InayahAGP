using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble10Script : MonoBehaviour
{
    public GameObject bubblePrefab; // bubble 10 prefab
    private bool hasExecuted = false;

    // this bubble is only allowed to be made after the cassette plays once
    // it can be found on computer icon (neo room)

    private void OnMouseDown()
    {
        // Check if the video has finished playing
        if (PlayCassette.Instance.isVideoFinished && !hasExecuted)
        {
            BubbleManager.Instance.CreateBubble(bubblePrefab);
            hasExecuted = true; // Prevent multiple executions
        }
        else if (!PlayCassette.Instance.isVideoFinished)
        {
            //Debug.Log("You can't trigger this bubble until the video has ended.");
        }
    }
}

