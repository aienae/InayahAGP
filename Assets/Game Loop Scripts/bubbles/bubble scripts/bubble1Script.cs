using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble1Script : MonoBehaviour
{
    private bool hasExecuted = false;
    public GameObject bubblePrefab;

    private void OnMouseDown()
    {
        if (!hasExecuted)
        {
            BubbleManager.Instance.CreateBubble(bubblePrefab);

            hasExecuted = true;
        }
        
    }
}
