using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif11Script : MonoBehaviour
{
    private static bool hasExecuted = false;
    public GameObject bubblePrefab; // notif 11 prefab

    private void OnMouseDown()
    {
        // happens only once
        if (!hasExecuted) 
        {
            NotifManager.Instance.CreateBubble(bubblePrefab);
            hasExecuted = true;
        }
        
    }
}
