using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirusCloseButton : MonoBehaviour
{
    public GameObject objecttohidee;
    public GameObject timertextToHide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        objecttohidee.SetActive(false);
        timertextToHide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
