using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageTextScript : MonoBehaviour
{
    private BoxScript boxscript;
    public TextMeshProUGUI StageText;

    public void ChangeStageText()
    {
        this.boxscript = FindObjectOfType<BoxScript>();
        StageText.text = Mathf.Round(boxscript.st + 1).ToString();
    }
}
