using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField] EquipmentDatabaseSO equipmentDatabaseSO;

    public void Start()
    {
        Debug.Log(equipmentDatabaseSO.equipmentDatas[0].attack);
    }
}

