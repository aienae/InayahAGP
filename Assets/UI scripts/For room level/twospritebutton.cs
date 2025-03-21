using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twospritebutton : MonoBehaviour
{
    public GameObject spritee1;
    public GameObject spritee2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        spritee1.SetActive(false);
        spritee2.SetActive(true);
    }

    private void makesprite1visibleAgain()
    {
        spritee1.SetActive(true);
        spritee2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
