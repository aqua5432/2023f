using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalStatesDisplayer : MonoBehaviour
{
    [SerializeField]
    StatesManager statesManager;

    [SerializeField]
    List<Slider> statesSlider;

    public void DisplayTotalStates()
    {
        int[] totalStates = statesManager.GetTotalStates();
        for(int i = 0; i < statesSlider.Count; i++)
        {
            Image fillImage = statesSlider[i].fillRect.GetComponent<Image>();
            fillImage.color = Color.white;
            statesSlider[i].value = totalStates[i];
        }
    }

    public void DisplayStatesDiff(int partsNumber, int fighterNumber)
    {
        var currentEquipmentData = statesManager.GetCurrentEquipmentData();
        var currentEquipmentStates = currentEquipmentData[partsNumber].GetStates();
        var mouseOverStates = statesManager.CallGetStates(partsNumber, fighterNumber);
        for(int i = 0; i < mouseOverStates.Length; i++)
        {
            int diff = mouseOverStates[i] - currentEquipmentStates[i];
            statesSlider[i].value = statesSlider[i].value + diff;

            Image fillImage = statesSlider[i].fillRect.GetComponent<Image>();
            if(diff < 0)
                fillImage.color = Color.red;
            else if (diff > 0)
                fillImage.color = Color.green;
        }
    }
}


