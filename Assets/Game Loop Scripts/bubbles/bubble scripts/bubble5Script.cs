using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble5Script : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubbleButton;
    public GameObject bubblePrefab;
    
    // this script is on the bubble 4 prefab button to spawn bubble 5

    private void OnMouseDown()
    {
        BubbleManager.Instance.CreateBubble(bubblePrefab);
        FindObjectOfType<Casette>().RegisterInstantiatedObject(bubblePrefab); // adds it to casette script
        Destroy(bubble);
        Destroy(bubbleButton);
    }
}
