using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] StageTextScript stageTextScript;
    AudioManager audioManager;

    static int stagenumber = 0;
    public int st
    {
        get { return stagenumber; }
        set { stagenumber = value; }
    }

    void Start()
    {
        audioManager = AudioManager.instance;
        st = 0;
    }

    public void DisplayBox()
    {
        int childCount = transform.childCount;

        for(int i = 0; i < childCount; i++)
        {
            GameObject box = transform.GetChild(i).gameObject;
            if (st == i)
            {
                box.SetActive(true);
                stageTextScript.ChangeStageText();
                audioManager.PlaySE(SEData.TITLE.Selection);
            }
            else
                box.SetActive(false);
        }
    }
}
