using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentChanger : MonoBehaviour
{
    [SerializeField]
    TotalStatesDisplayer totalStatesDisplayer;
    // partTypeは0:body 1:wing 2:thruster というように対応しています
    public void ChangeEquipment(int partsNumber, int fighterNumber)
    {
        Transform parts = transform.GetChild(partsNumber);
        
        int partsCount = parts.childCount;
        
        for(int i = 0; i < partsCount ; i++)
        {
            Transform equipment = parts.GetChild(i);

            if(i == fighterNumber)
                equipment.gameObject.SetActive(true);
            else
                equipment.gameObject.SetActive(false);
        }
    }
}
