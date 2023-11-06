using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTextScript : MonoBehaviour
{
    private LevelSliderScript levelsliderscript;
    public TextMeshProUGUI LevelValueText;

    void Update()
    {
        this.levelsliderscript = FindObjectOfType<LevelSliderScript>();
        float Level = levelsliderscript.lv;
        LevelValueText.text = Mathf.Round(levelsliderscript.lv).ToString();
    }
}
