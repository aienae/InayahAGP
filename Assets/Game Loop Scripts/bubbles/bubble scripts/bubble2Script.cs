using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble2Script : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubbleButton;

    // this script is just a destroy bubble script but it also triggers the msg notif 1 to appear

    private void OnMouseDown()
    {
        notif1Script.Instance.StartCreateNotif1(0.5f); // you can adjust the length of the delay for notif 1 here
        Destroy(bubble);
        Destroy(bubbleButton);
    }

}

