using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble4Script : MonoBehaviour
{
    private bool hasExecuted = false;
    public GameObject bubblePrefab;
    public GameObject PICchatLog;

    private void OnMouseDown()
    {
        if (!hasExecuted)
        {

            StartCoroutine(DelayedExecution(3f)); // 3-second delay
        }
    }

    private IEnumerator DelayedExecution(float delay)
    {
        // Wait until screenshot is actually active
        while (PICchatLog == null || !PICchatLog.activeInHierarchy)
        {
            yield return null; // Waits for the next frame
        }

        float timer = 0f;

        while (timer < delay)
        {
            if (PICchatLog == null || !PICchatLog.activeInHierarchy)
            {
                Debug.Log("Related object was deactivated before delay ended. Canceling execution.");
                yield break; // Stop the coroutine
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Only executes if the relatedObject stayed active during the delay
        BubbleManager.Instance.CreateBubble(bubblePrefab);
        FindObjectOfType<Casette>().RegisterInstantiatedObject(bubblePrefab); // adds it to casette script
        
        hasExecuted = true;
    }
}


