using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] StageTextScript stageTextScript;
    SEScript sEScript;

    static int stagenumber = 0;
    public int st
    {
        get { return stagenumber; }
        set { stagenumber = value; }
    }

    void Start()
    {
        sEScript = GetComponent<SEScript>();
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
                sEScript.AudioPlay();
            }
            else
                box.SetActive(false);
        }
    }
}
