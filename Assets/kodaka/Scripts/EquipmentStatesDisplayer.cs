using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipmentStatesDisplayer : MonoBehaviour
{
    StatesManager statesManager;

    // Attack、HP、Speedの順で入れないとダメ
    [SerializeField]
    List<TextMeshProUGUI> statesValues;

    public void Start()
    {
        DisplayEquipmentStates();
    }

    public void DisplayEquipmentStates()
    {
        statesManager = GameObject.Find("StatesManager").GetComponent<StatesManager>();

        int partsNumber = transform.parent.parent.parent.GetSiblingIndex();
        int fighterNumber = transform.parent.GetSiblingIndex();

        int[] equipmentStates = statesManager.GetStates(partsNumber, fighterNumber);

        DisplayStates(equipmentStates);
    }

    public void DisplayStates(int[] statesArray)
    {
        for(int i = 0; i < statesValues.Count; i++)
        {
            statesValues[i].text = statesArray[i].ToString();
        }
    }
}


