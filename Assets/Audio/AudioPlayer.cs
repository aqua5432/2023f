using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    AudioManager audioManager;
    AudioMixer audioMixer;

    [SerializeField] BGMData.TITLE title;

    void Start()
    {
        audioManager = AudioManager.instance;
        audioMixer = audioManager.audioMixer;

        ResetVolume("BGM", "bgmSliderValue");
        ResetVolume("SE", "seSliderValue");
        ResetVolume("Voice", "voiceSliderValue");

        if(!audioManager.isSameBGM(title))
        {
            audioManager.PlayBGM(title);
        }
    }

    public void ResetVolume(string mixerGroup, string sliderValueKey)
    {
        float sliderValue = PlayerPrefs.GetFloat(sliderValueKey, 1);
        float volume = Mathf.Clamp(Mathf.Log10(sliderValue) * 20, -80, 0);
        audioMixer.SetFloat(mixerGroup, volume);
    }

    // ----------------------------------------------------------

    // この関数がクリックイベントで選択できないのはなぜ
    public void PlaySE(SEData.TITLE tITLE)
    {
        audioManager.PlaySE(tITLE);
    }

    public void PlaySelectionSE()
    {
        audioManager.PlaySE(SEData.TITLE.Selection);
    }

    public void PlayPurchaseSE()
    {
        audioManager.PlaySE(SEData.TITLE.Purchase);
    }
}
