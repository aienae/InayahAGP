using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneObjForSprite : MonoBehaviour
{
    public GameObject objecttoshow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        objecttoshow.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
