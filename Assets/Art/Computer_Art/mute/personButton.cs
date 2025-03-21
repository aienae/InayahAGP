using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personButton : MonoBehaviour
{   
    public GameObject UIperson;
    public GameObject UIStimulants;
    public GameObject UIbioparts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        UIperson.SetActive(true);
        UIbioparts.SetActive(false);
        UIStimulants.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
