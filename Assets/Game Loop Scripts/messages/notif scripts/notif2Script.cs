using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif2Script : MonoBehaviour
{
    public static notif2Script Instance;
    public GameObject bubblePrefab; // notif 2 prefab
    private bool hasExecuted = false; // Ensures the method only runs once

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

    public void CreateNotif2()
    {
        NotifManager.Instance.CreateBubble(bubblePrefab); // instantiates msg notif1 after seconds

        // subscribe to the bubble destroyed event to know when the bubble gets destroyed
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed += OnBubbleFadeComplete;
        }
    }

    private void OnBubbleFadeComplete()
    {
        // Ensure this method only executes once
        if (hasExecuted) return;
        hasExecuted = true;

        Debug.Log("Bubble has faded out! Now executing another method.");
        notif3Script.Instance.CreateNotif3();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}
