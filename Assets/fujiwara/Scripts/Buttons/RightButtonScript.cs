using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonScript : MonoBehaviour
{
    private LeftButtonScript LBS;
    static int Rstagenumber = 1;
    public int RSN
    {
        get { return Rstagenumber; }
        set { Rstagenumber = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickRightButton()
    {

        if (RSN < 3)
        {
            RSN += 1;
        }
        this.LBS = FindObjectOfType<LeftButtonScript>();
        LBS.LSN = RSN;
    }
}