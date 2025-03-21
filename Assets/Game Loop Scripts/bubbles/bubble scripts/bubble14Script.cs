using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble14Script : MonoBehaviour
{
    public GameObject bubblePrefab;
    private bool hasExecuted = false;

    private void OnMouseDown()
    {   // only happens once
        if (!hasExecuted)
        {
            BubbleManager.Instance.CreateBubble(bubblePrefab);
            hasExecuted = true;
        }
    }
}
