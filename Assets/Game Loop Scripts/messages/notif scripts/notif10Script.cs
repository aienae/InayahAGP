using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif10Script : MonoBehaviour
{
    public static notif10Script Instance;
    public GameObject bubblePrefab; // notif 10 prefab

    public bool notif10Triggered = false; // Tracks if notif10 has been created

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

    public void CreateNotif10()
    {
        NotifManager.Instance.CreateBubble(bubblePrefab); // Instantiates notif10
        notif10Triggered = true; // Mark as triggered and enables the documents folder contents to be seen
    }
}

