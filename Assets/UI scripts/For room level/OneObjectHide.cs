using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bruh : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectt;

    void Start()
    {
        
    }

    public void makehidden()
    {
        objectt.SetActive(false);
    }

    public void makevisibile()
    {
        objectt.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
