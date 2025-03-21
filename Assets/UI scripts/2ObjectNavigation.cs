using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_to_settings : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    public void Object1_Visible()
    {
        object1.SetActive(false);
        object2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
