using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble12Script : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubbleButton;
    public GameObject bubblePrefab; // bubble 12

    // this script is on bubble 11 button

    private void OnMouseDown()
    {
        BubbleManager.Instance.CreateBubble(bubblePrefab);
        Destroy(bubble);
        Destroy(bubbleButton);
    }
}
