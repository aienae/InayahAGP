using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInternet : MonoBehaviour
{
    public GameObject internetEmpty;
    public GameObject UIpersonlist;
    public GameObject UIstimulants;
    public GameObject UIbioparts;
    public GameObject UImeyenaPosts;
    public GameObject UIpassword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        internetEmpty.SetActive(false);
        UIbioparts.SetActive(false);
        UIstimulants.SetActive(false);
        UIbioparts.SetActive(false);
        UImeyenaPosts.SetActive(false);
        UIpassword.SetActive(false);
        UIpersonlist.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
