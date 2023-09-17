
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
    [SerializeField] int deffence;
    [SerializeField] int hp;
    [SerializeField] int speed;
    [SerializeField] int critRate;

    public enum states
    {
        attack,
        deffence,
        hp,
        speed,
        critRate
    }

    public int[] GetStates()
    {
        var states = new int[]
        {
            attack,
            deffence,
            hp,
            speed,
            critRate,

        };
        return states;
    }

    public int GetAttack()
    {
        return attack;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetSpeed()
    {
        return speed;
    }
}