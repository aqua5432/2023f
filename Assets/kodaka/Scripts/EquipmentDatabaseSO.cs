
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentDatabaseSO : ScriptableObject
{
    public List<EquipmentData> equipmentDatabase = new List<EquipmentData>();
}

[System.Serializable]
public class EquipmentData
{
    [SerializeField] int attack;    
    [SerializeField] int hp;
    [SerializeField] int speed;
    [SerializeField] int critRate;
    [SerializeField] int critDamage;
    [SerializeField] int evasionRate;
    [SerializeField] int cTDecreaseRate;

    [SerializeField] int price;

    public enum States
    {
        attack,
        hp,
        speed,
        critRate,
        critDamage,
        evasionRate,
        cTDecreaseRate
    }

    public enum Parts
    {
        body,
        wing,
        thruster
    }

    public int[] GetStates()
    {
        var states = new int[]
        {
            attack,
            hp,
            speed,
            critRate,
            critDamage,
            evasionRate,
            cTDecreaseRate
        };
        return states;
    }

    public int GetPrice()
    {
        return price;
    }
}