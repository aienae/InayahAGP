using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble15Script : MonoBehaviour
{
    public static bubble15Script Instance;
    public GameObject bubblePrefab; // bubble 15 prefab

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

    public void CreateBubble15()
    {
        BubbleManager.Instance.CreateBubble(bubblePrefab); 
    }
}
