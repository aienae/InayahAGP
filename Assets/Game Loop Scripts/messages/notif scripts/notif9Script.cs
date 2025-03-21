using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif9Script : MonoBehaviour
{
    public GameObject bubblePrefab; // notif 9 prefab
    public static notif9Script Instance;
    private bool hasExecuted = false;

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
    

    public void CreateNotif9()
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

        notif10Script.Instance.CreateNotif10();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}
