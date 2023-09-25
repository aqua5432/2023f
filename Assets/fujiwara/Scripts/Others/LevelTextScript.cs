using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTextScript : MonoBehaviour
{
    private LevelSliderScript levelsliderscript;
    public TextMeshProUGUI LevelValueText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.levelsliderscript = FindObjectOfType<LevelSliderScript>();
        float Level = levelsliderscript.lv;
        LevelValueText.text = Mathf.Round(levelsliderscript.lv).ToString();
    }
}
