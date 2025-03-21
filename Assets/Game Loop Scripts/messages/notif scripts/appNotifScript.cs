using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appNotifScript : MonoBehaviour
{
    public static appNotifScript Instance;
    public GameObject bubblePrefab; // app added prefab

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

    public void CreateAppNotif()
    {
        StartCoroutine(DelayedNotification(1f)); // Start the coroutine with a 1-second delay
    }

    private IEnumerator DelayedNotification(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 1 second

        AppAddedScript.Instance.CreateBubble(bubblePrefab); // Instantiate the notification after delay

        // you can add code that shows code breaker button here
    }
}