using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif15Script : MonoBehaviour
{
    private static bool hasExecuted = false;
    private bool hasExecuted2 = false;
    public GameObject bubble; // bubble 14
    public GameObject bubbleButton; // bubble 14
    public GameObject bubblePrefab; // notif 15 prefab

    // this script is found on bubble 14's button, it instantiaes notif 15 then after fade, creates bubble 15
    private void OnMouseDown()
    {
        // destroy bubble 14
        Destroy(bubble);
        Destroy(bubbleButton);

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

        bubble15Script.Instance.CreateBubble15();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}
