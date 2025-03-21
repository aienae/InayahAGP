using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ImageString>().AddImage(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
