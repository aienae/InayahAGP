using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBreakerButton : MonoBehaviour
{      
    public GameObject codebreakerPagee;
    public GameObject puzzle1UI;

    private void OnMouseDown()
    {
        codebreakerPagee.SetActive(true);
        puzzle1UI.SetActive(true);
    }

}
