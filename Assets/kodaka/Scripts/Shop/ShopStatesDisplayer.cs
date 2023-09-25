using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopStatesDisplayer : MonoBehaviour
{
    [SerializeField] StatesManager statesManager;

    [SerializeField] List<Slider> slider;

    public void DisplayStates(int partsNumber, int fighterNumber)
    {
        var states = statesManager.CallGetStates(partsNumber, fighterNumber);
        for(int i = 0; i < states.Length; i++)
        {
            Image fillImage = slider[i].fillRect.GetComponent<Image>();
            fillImage.color = Color.white;
            slider[i].value = states[i];
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
            slider[i].value = slider[i].value + diff;

            Image fillImage = slider[i].fillRect.GetComponent<Image>();
            if(diff < 0)
                fillImage.color = Color.red;
            else if (diff > 0)
                fillImage.color = Color.green;
        }
    }
}
