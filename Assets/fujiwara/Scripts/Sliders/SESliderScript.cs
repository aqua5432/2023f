using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{
    [SerializeField] Slider seSlider;

    AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        // audioSourceを初期化する前にvalueを変更しているため、最初は効果音が鳴らない（ヌルチェックに引っかかって音が鳴らない）
        float seSliderValue = PlayerPrefs.GetFloat("seSliderValue", 1);
        seSlider.value = seSliderValue;
        
        audioSource = SEObjectScript.instance.GetComponent<AudioSource>();
    }

    public void PlaySampleSound()
    {
        if(audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
