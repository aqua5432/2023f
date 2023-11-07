using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public float seSliderValue;
    public float voiceSliderValue;

    public void SetBGM(float sliderValue)
    {
        PlayerPrefs.SetFloat("bgmSliderValue", sliderValue);
        float volume = Mathf.Clamp(Mathf.Log10(sliderValue) * 20, -80, 0);
        audioMixer.SetFloat("BGM", volume);
    }
    
    public void SetSE(float sliderValue)
    {
        PlayerPrefs.SetFloat("seSliderValue", sliderValue);
        float volume = Mathf.Clamp(Mathf.Log10(sliderValue) * 20, -80, 0);
        audioMixer.SetFloat("SE", volume);
        
    }

    public void SetVoice(float sliderValue)
    {
        PlayerPrefs.SetFloat("voiceSliderValue", sliderValue);
        float volume = Mathf.Clamp(Mathf.Log10(sliderValue) * 20 + 15, -80, 15);
        audioMixer.SetFloat("Voice", volume);
    }
}
