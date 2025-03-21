using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif13Script : MonoBehaviour
{
    public static notif13Script Instance;
    public GameObject bubblePrefab; // notif 13 prefab

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

    public void CreateNotif13()
    {
        NotifManager.Instance.CreateBubble(bubblePrefab); // instantiates msg notif13
    }
}
