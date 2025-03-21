using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBreakerButton : MonoBehaviour
{
    public GameObject codebreakerPage;
    public GameObject addedImagesConatiner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        codebreakerPage.SetActive(false);
        addedImagesConatiner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
