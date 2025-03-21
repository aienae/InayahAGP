using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifiSlideUp : MonoBehaviour
{
    public Animator wifiSlideUpAnimator; 
    private bool isWifiVisible = false; 

    private void OnMouseDown()
    {
        if (wifiSlideUpAnimator != null)
        {
            if (isWifiVisible)
            {
                // Reverse animation for slide down
                wifiSlideUpAnimator.SetFloat("SlideSpeed", -1f); // Play backward
                wifiSlideUpAnimator.Play("slideUpWIFI", 0, 1f); // start from the end
                Debug.Log("Slide down animation triggered.");
            }
            else
            {
                // Play the animation normally for slide up
                wifiSlideUpAnimator.SetFloat("SlideSpeed", 1f); // Play forward
                wifiSlideUpAnimator.Play("slideUpWIFI", 0, 0f); // Start from the beginning
                Debug.Log("Slide up animation triggered.");
            }

            isWifiVisible = !isWifiVisible; // Toggle visibility
        }
        else
        {
            Debug.LogError("Animator not assigned.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


