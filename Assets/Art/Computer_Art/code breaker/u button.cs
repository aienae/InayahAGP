using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ubutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ImageString>().AddImage(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
