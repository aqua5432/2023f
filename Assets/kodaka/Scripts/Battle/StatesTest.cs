using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesTest : MonoBehaviour
{
    public EquipmentDatabaseSO so;

    void Start()
    {
        int body = PlayerPrefs.GetInt("bodyFighterNumber", 100);
        int wing = PlayerPrefs.GetInt("wingFighterNumber", 100);
        int thruster = PlayerPrefs.GetInt("thrusterFighterNumber", 100);
        Debug.Log(body);
        Debug.Log(wing);
        Debug.Log(thruster);

        // ステータス
        int attack = PlayerPrefs.GetInt("attack", 0);
        int hp = PlayerPrefs.GetInt("hp", 0);
        int speed = PlayerPrefs.GetInt("speed", 0);
        int critRate = PlayerPrefs.GetInt("critRate", 0);
        int critDamage = PlayerPrefs.GetInt("critDamage", 0);
        int evasionRate = PlayerPrefs.GetInt("evasionRate", 0);
        int cTDecreaseRate = PlayerPrefs.GetInt("cTDecreaseRate", 0);

        Debug.Log(attack);
        Debug.Log(evasionRate);
        
        var equipmentData = so.equipmentDatabase[0];
        var states = equipmentData.GetStates();
        Debug.Log(states);
    }
}
