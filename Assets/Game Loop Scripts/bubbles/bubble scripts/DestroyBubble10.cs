using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBubble10 : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubbleButton;

    private void OnMouseDown()
    {
        notif7Script.Instance.CreateNotif7();
        Destroy(bubble);
        Destroy(bubbleButton);
    }
}
