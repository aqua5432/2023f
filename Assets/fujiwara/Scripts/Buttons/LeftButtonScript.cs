using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonScript : MonoBehaviour
{
    [SerializeField] BoxScript boxScript;

    public void OnClickLeftButton()
    {
        if(0 < boxScript.st)
        {
            boxScript.st--;
        }

        boxScript.DisplayBox();
    }
}
