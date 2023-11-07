using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{
    [SerializeField] Slider seSlider;
    float preTime;
    bool canPlaySound;

    void Start()
    {
        canPlaySound = false;
        
        float seSliderValue = PlayerPrefs.GetFloat("seSliderValue", 1);
        seSlider.value = seSliderValue;

        preTime = 0;

        canPlaySound = true;
    }

    public void PlaySampleVoice()
    {
        if(canPlaySound && (Time.time - preTime) > 0.3f)
        {
            AudioManager.instance.PlaySE(SEData.TITLE.Selection);
            preTime = Time.time;
        }
    }
}
