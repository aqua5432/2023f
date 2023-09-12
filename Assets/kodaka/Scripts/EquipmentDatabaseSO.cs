using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentDatabaseSO : ScriptableObject
{
    public List<EquipmentData> equipmentDatas = new List<EquipmentData>();
}

[System.Serializable]
public class EquipmentData
{
    public string part;
    public int attack;
    public int hp;
    public int speed;
}