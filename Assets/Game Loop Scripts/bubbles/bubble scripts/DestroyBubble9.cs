using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBubble9 : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubbleButton;
    
    // this script is found on ubble 9 buton, it destroys both the bubble and cassette
    private void OnMouseDown()
    {
        Destroy(bubble);
        Destroy(bubbleButton);
        
        // destroy the cassette 
        if (bubble9Script.instantiatedCasette != null)
        {
            Destroy(bubble9Script.instantiatedCasette);
            bubble9Script.instantiatedCasette = null; // Clear the reference after destruction
            Debug.Log("Cassette has been destroyed!");
        }

        PlayCassette.Instance.playKidnapVCR(); // after destroy the bubble, play the video in another script
    }
}  
