using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleController : MonoBehaviour
{
    GameObject equipmentChanger;
    public EquipmentChanger equipmentChange;

    public void CallChangeEquipment()
    {
        equipmentChanger = GameObject.Find("FighterView");


        int toggleIndex = transform.GetSiblingIndex();
        int groupIndex = transform.parent.parent.GetSiblingIndex();

        equipmentChanger.GetComponent<EquipmentChanger>().ChangeEquipment(groupIndex, toggleIndex);
    }
}
    
