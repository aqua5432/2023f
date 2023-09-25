using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSliderScript : MonoBehaviour
{
    [SerializeField] Slider LevelSlider;
    static float Level = 2;
    public float lv
    {
        get { return Level; }
        set { Level = value; }
    }

    public void SetLevel(float level)
    {
        LevelSlider.value = level;
        lv = level;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelSlider.value = lv;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   
}