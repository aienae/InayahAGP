using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif1Script : MonoBehaviour
{
    public static notif1Script Instance;
    public GameObject bubblePrefab; // notif 1 prefab
    private bool hasExecuted = false; // Ensures the method only runs once

    // this script is called from bubble 2 script

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

    public void StartCreateNotif1(float delay)
    {
        StartCoroutine(CreateNotif1(delay));

        // Subscribe to the bubble destroyed event
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed += OnBubbleFadeComplete;
        }
    }

    private IEnumerator CreateNotif1(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Debug.Log("This happens after the delay.");
        NotifManager.Instance.CreateBubble(bubblePrefab); // instantiates msg notif1 after seconds
    }

    private void OnBubbleFadeComplete()
    {
        // Ensure this method only executes once
        if (hasExecuted) return;
        hasExecuted = true;

        //Debug.Log("Bubble has faded out! Now executing another method.");
        notif2Script.Instance.CreateNotif2();

        // Unsubscribe from the event after execution
        if (NotifManager.Instance != null)
        {
            NotifManager.Instance.OnBubbleDestroyed -= OnBubbleFadeComplete;
        }
    }
}
