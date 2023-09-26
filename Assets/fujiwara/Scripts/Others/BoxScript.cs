using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private RightButtonScript RBS;
    static int stagenumber = 1;
    public int st
    {
        get { return stagenumber; }
        set { stagenumber = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        stagenumber = st;
    }

    // Update is called once per frame

    public void DisplayBox()
    {
        this.RBS = FindObjectOfType<RightButtonScript>();
        st = RBS.RSN;

        int childCount = transform.childCount;

        for(int i = 0; i < childCount; i++)
        {
            GameObject box = transform.GetChild(i).gameObject;
            if (st == (i + 1))
                box.SetActive(true);
            else
                box.SetActive(false);
        }
    }
}
