using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider BGMVolumeSlider;
    [SerializeField] Slider SEVolumeSlider;
    [SerializeField] Slider VoiceVolumeSlider;


    static float bgm = -20;
    public float BGM
    {
        get { return bgm; }
        set { bgm = value; }
    }

    static float se = -20;
    public float SE
    {
        get { return se; }
        set { se = value; }
    }

    static float voice = -20;
    public float Voice
    {
        get { return voice; }
        set { voice = value; }
    }

    public void start()
    {
        audioMixer.GetFloat("BGM", out float BGMVolume);
        BGMVolumeSlider.value = BGMVolume;

        audioMixer.GetFloat("SE", out float SEVolume);
        SEVolumeSlider.value = SEVolume;
        
        audioMixer.GetFloat("Voice", out float VoiceVolume);
        VoiceVolumeSlider.value = VoiceVolume;
    }
   

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
        bgm = volume;
    }
    
    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
        se = volume;
    }

    public void SetVoice(float volume)
    {
        audioMixer.SetFloat("Voice", volume);
        voice = volume;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
