using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ImageString>().AddImage(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
