using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceSliderScript : MonoBehaviour
{
    [SerializeField] Slider voiceSlider;
    [SerializeField] AudioClip sampleVoice;

    AudioSource audioSource;
    bool canPlaySound;

    void Start()
    {
        canPlaySound = false;

        float voiceSliderValue = PlayerPrefs.GetFloat("voiceSliderValue", 1);
        voiceSlider.value = voiceSliderValue;

        audioSource = AudioManager.instance.voiceAudioSource;

        canPlaySound = true;
    }

    public void PlaySampleSound()
    {
        if(canPlaySound && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sampleVoice);
        }
    }
}
