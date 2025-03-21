using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notif5Script : MonoBehaviour
{
    public static notif5Script Instance;
    public GameObject bubblePrefab; // notif 5 prefab

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

    public void CreateNotif5()
    {
        NotifManager.Instance.CreateBubble(bubblePrefab); // instantiates msg notif1 after seconds
    }

}
