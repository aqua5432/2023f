using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public StatesManager statesManager;
    public EquipmentChanger equipmentChanger;
    public TotalStatesDisplayer totalStatesDisplayer;


    public void OnClickToggle(int partsNumber)
    {
        int fighterNumber = transform.GetSiblingIndex();
        statesManager.SetCurrentEquipment(partsNumber, fighterNumber);
        equipmentChanger.ChangeEquipment(partsNumber, fighterNumber);
        totalStatesDisplayer.DisplayTotalStates();
    }
}
    
