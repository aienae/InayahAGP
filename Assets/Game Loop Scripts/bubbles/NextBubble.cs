using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBubble : MonoBehaviour
{
    public GameObject bubblePrefab;

    private void OnMouseDown()
    {
        BubbleManager.Instance.CreateBubble(bubblePrefab);  
    }

}
