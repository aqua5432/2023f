using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSliderScript : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioScript audioscript;
    [SerializeField] Slider BGMVolumeSlider;
 

    void Start()
    {
        this.audioscript = FindObjectOfType<AudioScript>();
        float BGMvolume = audioscript.BGM;
        BGMVolumeSlider.value = audioscript.BGM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
