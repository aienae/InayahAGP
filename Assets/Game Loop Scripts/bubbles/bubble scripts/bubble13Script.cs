using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubble13Script : MonoBehaviour
{
    private bool hasExecuted = false;
    public GameObject bubblePrefab; // notif 12 prefab
    public ScrollRect scrollRect; // Reference to the Scroll View
    private bool hasReachedEnd = false; // Ensure the code runs only once


    void Update()
    {
        // Check if it's a vertical scroll
        if (!hasReachedEnd && scrollRect.verticalNormalizedPosition <= 0.01f)
        {
            OnScrollEnd();
            hasReachedEnd = true; // Prevent repeated calls
        }

        // Optional: Reset if scrolling up again
        if (hasReachedEnd && scrollRect.verticalNormalizedPosition > 0.01f)
        {
            hasReachedEnd = false;
        }
    }

    private void OnScrollEnd()
    {
        Debug.Log("Reached the end of the scroll!");

        if (!hasExecuted) 
        {
            BubbleManager.Instance.CreateBubble(bubblePrefab);

            hasExecuted = true;

        }
    }
}
