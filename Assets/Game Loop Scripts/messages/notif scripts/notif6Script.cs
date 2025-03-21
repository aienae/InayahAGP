using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif6Script : MonoBehaviour
{
    private bool hasExecuted = false;
    public GameObject bubblePrefab; // notif 6 prefab

    private void OnMouseDown()
    {
        // happens only once
        if (!hasExecuted) 
        {
            NotifManager.Instance.CreateBubble(bubblePrefab);
            FindObjectOfType<Casette>().RegisterInstantiatedObject(bubblePrefab); // adds it to the casette tape script

            hasExecuted = true;

        }
    }
}
