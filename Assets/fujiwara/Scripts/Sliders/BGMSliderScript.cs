using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSliderScript : MonoBehaviour
{
    [SerializeField] Slider bgmSlider;

    void Start()
    {
        float bgmSliderValue = PlayerPrefs.GetFloat("bgmSliderValue", 1);
        bgmSlider.value = bgmSliderValue;
    }
}
