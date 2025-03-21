using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybubble : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubbleButton;

    private void OnMouseDown()
    {
        Destroy(bubble);
        Destroy(bubbleButton);
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
