using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif4Script : MonoBehaviour
{
    private static bool hasExecuted = false;
    private bool hasExecuted2 = false;
    public GameObject bubblePrefab; // notif 4 prefab

    private void OnMouseDown()
    {
        // happens only once
        if (!hasExecuted) 
        {
            NotifManager.Instance.CreateBubble(bubblePrefab);
            hasExecuted = true;

            if (NotifManager.Instance != null)
            {
                NotifManager.Instance.OnBubbleDestroyed += OnBubbleFadeComplete;
            }
        }
        
    }

    private void OnBubbleFadeComplete()
    {
        // Ensure this method only executes once
        if (hasExecuted2) return;
        hasExecuted2 = true;

        Debug.Log("Bubble has faded out! Now executing another method.");
        notif5Script.Instance.CreateNotif5();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}


