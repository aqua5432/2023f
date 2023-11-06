using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonScript : MonoBehaviour
{
    [SerializeField] BoxScript boxScript;

    public void OnClickRightButton()
    {
        if(boxScript.st < 2)
        {
            boxScript.st++;
        }

        boxScript.DisplayBox();
    }
}
