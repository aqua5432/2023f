using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonScript : MonoBehaviour
{
     private RightButtonScript RBS;
     static int Lstagenumber = 1;
     public int LSN
     {
         get {return Lstagenumber;}
         set { Lstagenumber = value; } 
     }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickLeftButton()
    {

        if (LSN > 1)
        {
            LSN -= 1;
        }
        this.RBS = FindObjectOfType<RightButtonScript>();
        RBS.RSN = LSN;
    }

}
