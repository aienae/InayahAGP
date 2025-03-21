using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public Slider volslider;
    public AudioSource audiosourcee;

    // Start is called before the first frame update
    void Start()
    {
        float savedVol = PlayerPrefs.GetFloat("MusicVol", 0.5f);
        volslider.value = savedVol;

        volslider.onValueChanged.AddListener(AdjustVolume);
    }

    void AdjustVolume(float value)
    {
        audiosourcee.volume = value;

        PlayerPrefs.SetFloat("MusicVol", value);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
