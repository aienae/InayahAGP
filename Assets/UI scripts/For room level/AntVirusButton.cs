using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntVirusButton : MonoBehaviour
{
    public GameObject objecttoshoww;
    public GameObject timertexttoShow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        objecttoshoww.SetActive(true);
        timertexttoShow.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
