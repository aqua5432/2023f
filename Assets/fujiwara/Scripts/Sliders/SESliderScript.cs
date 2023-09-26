using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{

    private AudioScript audiocript;
    [SerializeField] Slider SEVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        this.audiocript = FindObjectOfType<AudioScript>();
        float SEVolume = audiocript.SE;
        SEVolumeSlider.value = audiocript.SE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
