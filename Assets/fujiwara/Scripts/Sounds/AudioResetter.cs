using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioResetter : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    void Start()
    {
        ResetVolume("BGM", "bgmSliderValue");
        ResetVolume("SE", "seSliderValue");
        ResetVolume("Voice", "voiceSliderValue");
    }

    void ResetVolume(string mixerGroup, string sliderValueKey)
    {
        float sliderValue = PlayerPrefs.GetFloat(sliderValueKey, 1);
        float volume = Mathf.Clamp(Mathf.Log10(sliderValue) * 20, -80, 0);
        audioMixer.SetFloat(mixerGroup, volume);
    }
}
