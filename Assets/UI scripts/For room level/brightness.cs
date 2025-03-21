using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class brightness : MonoBehaviour
{
    public Slider brightslider;
    public Light2D globallight;
    // Start is called before the first frame update
    void Start()
    {
        float savedBrightness = PlayerPrefs.GetFloat("brightvalue");
        brightslider.value = savedBrightness;

        adjustbrightness(brightslider.value);
        brightslider.onValueChanged.AddListener(adjustbrightness);
        
    }

    // Update is called once per frame
    public void adjustbrightness(float value)
    {
        globallight.intensity = value;

        PlayerPrefs.SetFloat("brightvalue", value);
        PlayerPrefs.Save();
    }
    void Update()
    {
        
    }
}
