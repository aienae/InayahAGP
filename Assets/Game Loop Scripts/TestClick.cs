using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log($"{name} clicked");
    }
}
