using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButtons : MonoBehaviour
{
    public GameObject buttons;

    public void ToggleButtons()
    {
        int buttonCount = transform.childCount;

        for(int i = 0; i < buttonCount; i++)
        {
            Transform childButton = transform.GetChild(i);
            childButton.gameObject.SetActive(!childButton.gameObject.activeSelf);
        }
    }
}
