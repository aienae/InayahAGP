using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threespritehide : MonoBehaviour
{
    public GameObject spriteee1;
    public GameObject spriteee2;
    public GameObject spriteee3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        spriteee1.SetActive(false);
        spriteee2.SetActive(true);
        spriteee3.SetActive(true);
    }

    private void showagain()
    {
        spriteee1.SetActive(true);
        spriteee2.SetActive(false);
        spriteee3.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
