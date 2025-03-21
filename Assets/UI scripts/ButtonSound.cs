using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSound : MonoBehaviour
{
    public AudioSource SoundAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        SoundAudioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
