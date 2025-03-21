using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColourPress : MonoBehaviour
{
    private Renderer buttonRenderer;
    private Color originalColor;
    public Color pressedColor = Color.gray; 

    private void Start()
    {
        buttonRenderer = GetComponent<Renderer>();

        if (buttonRenderer != null)
        {
            originalColor = buttonRenderer.material.color; // Save original color
        }
        else
        {
            Debug.LogError("Renderer not found on the GameObject.");
        }
    }

    private void OnMouseDown()
    {
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = pressedColor; // Change to pressed color
        }
    }

    private void OnMouseUp()
    {
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = originalColor; // Reset to original color
        }
    }
}

