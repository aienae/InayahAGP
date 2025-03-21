using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private System.Action onClickAction;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="action">The action to execute when the button is clicked.</param>
    public void Setup(System.Action action)
    {
        onClickAction = action;
    }

    private void OnMouseDown()
    {
        onClickAction?.Invoke(); 
    }
}

