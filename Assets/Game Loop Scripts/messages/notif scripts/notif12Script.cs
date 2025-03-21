using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notif12Script : MonoBehaviour
{
    private bool hasExecuted = false;
    private bool hasExecuted2 = false; // Ensures the method only runs once
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
            NotifManager.Instance.CreateBubble(bubblePrefab);
            appNotifScript.Instance.CreateAppNotif();

            // subcribe to the fade out event
            if (NotifManager.Instance != null)
            {
                NotifManager.Instance.OnBubbleDestroyed += OnBubbleFadeComplete;
            }

            hasExecuted = true;

        }
    }

    private void OnBubbleFadeComplete()
    {
        // Ensure this method only executes once
        if (hasExecuted2) return;
        hasExecuted2 = true;

        notif13Script.Instance.CreateNotif13();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}

