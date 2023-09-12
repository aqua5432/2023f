using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentChanger : MonoBehaviour
{
    public void ChangeEquipment(int groupIndex, int toggleIndex)
    {
        Transform parts = transform.GetChild(groupIndex);
        int partsCount = parts.childCount;
        
        for(int i = 0; i < partsCount ; i++)
        {
            Transform equipment = parts.GetChild(i);

            if(i == toggleIndex)
                equipment.gameObject.SetActive(true);
            else
                equipment.gameObject.SetActive(false);
        }
    }
}
