using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble7Script : MonoBehaviour
{
    private bool hasExecuted = false;
    public GameObject bubblePrefab; // bubble 7
    public GameObject screenshot;

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
        while (screenshot != null && !screenshot.activeInHierarchy)
        {
            yield return null; // Waits for the next frame
        }

        float timer = 0f;

        while (timer < delay)
        {
            if (screenshot == null || !screenshot.activeInHierarchy)
            {
                Debug.Log("Related object was deactivated before delay ended. Canceling execution.");
                yield break; // Stop the coroutine
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Only executes if screenshot stayed active during the delay
        BubbleManager.Instance.CreateBubble(bubblePrefab);
        FindObjectOfType<Casette>().RegisterInstantiatedObject(bubblePrefab);
        
        hasExecuted = true;
        //Debug.Log("bubble 7 made");
    }

}
