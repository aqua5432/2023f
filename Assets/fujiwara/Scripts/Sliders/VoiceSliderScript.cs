using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceSliderScript : MonoBehaviour
{
    [SerializeField] Slider voiceSlider;

    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        float voiceSliderValue = PlayerPrefs.GetFloat("voiceSliderValue", 1);
        voiceSlider.value = voiceSliderValue;
        
        audioSource.clip = audioClip;
    }

    public void PlaySampleSound()
    { 
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }
}
