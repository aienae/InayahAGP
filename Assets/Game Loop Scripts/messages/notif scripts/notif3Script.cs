using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif3Script : MonoBehaviour
{
    public static notif3Script Instance;
    public GameObject bubblePrefab; // notif 3 prefab
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

    public void CreateNotif3()
    {
        NotifManager.Instance.CreateBubble(bubblePrefab); 

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

        instruction1.Instance.CreateInstruction1();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}
