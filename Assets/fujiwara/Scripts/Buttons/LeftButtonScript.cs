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

    public void OnClickLeftButton()
    {
        if (LSN > 1)
        {
            LSN -= 1;
        }
        this.RBS = FindObjectOfType<RightButtonScript>();
        RBS.RSN = LSN;
        Debug.Log("LSN" + LSN);
    }

}
