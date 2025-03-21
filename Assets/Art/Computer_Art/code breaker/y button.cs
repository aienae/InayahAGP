using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ybutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ImageString>().AddImage(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
