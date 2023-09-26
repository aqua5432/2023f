using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageTextScript : MonoBehaviour
{
    private BoxScript boxscript;
    public TextMeshProUGUI StageText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.boxscript = FindObjectOfType<BoxScript>();
        int stage = boxscript.st;
        StageText.text = Mathf.Round(boxscript.st).ToString();
    }
}
