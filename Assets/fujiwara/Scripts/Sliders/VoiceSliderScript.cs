using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceSliderScript : MonoBehaviour
{
    private AudioScript audioscript;
    [SerializeField] Slider VoiceVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        this.audioscript = FindObjectOfType<AudioScript>();
        float VoiceVolume = audioscript.Voice;
        VoiceVolumeSlider.value = audioscript.Voice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
