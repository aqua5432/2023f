using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatesManager : MonoBehaviour
{

    public EquipmentDatabaseSO bodyDatabaseSO;
    public EquipmentDatabaseSO wingDatabaseSO;
    public EquipmentDatabaseSO thrusterDatabaseSO;
    EquipmentDatabaseSO[] equipmentDatabaseSOs;

    EquipmentData currentBodyData;
    EquipmentData currentWingData;
    EquipmentData currentThrusterData;
    EquipmentData[] currentEquipmentData;

    int currentBodyFighterNumber = 0;
    int currentWingFighterNumber = 0;
    int currentThrusterFighterNumber = 0;

    int totalAttack = 0;
    int totalHp = 0;
    int totalSpeed = 0;
    int totalCritRate = 0;
    int totalCritDamage = 0;
    int totalEvasion = 0;
    int totalCTDecreaseRate = 0;
    int[] totalStates;

    public void Awake()
    {
        //　最初に設定されているパーツを取ってくる
        currentBodyData = bodyDatabaseSO.equipmentDatabase[currentBodyFighterNumber];
        currentWingData = wingDatabaseSO.equipmentDatabase[currentWingFighterNumber];
        currentThrusterData = thrusterDatabaseSO.equipmentDatabase[currentThrusterFighterNumber];

        //　数字(partNumber)でそれぞれのデータベースにアクセスできるように、配列にする。
        equipmentDatabaseSOs = new EquipmentDatabaseSO[]
        {
            bodyDatabaseSO,
            wingDatabaseSO,
            thrusterDatabaseSO
        };

        currentEquipmentData = new EquipmentData[]
        {
            currentBodyData,
            currentWingData,
            currentThrusterData
        };
        
        totalStates = new int[]
        {
            totalAttack,
            totalHp,
            totalSpeed,
            totalCritRate,
            totalCritDamage,
            totalEvasion,
            totalCTDecreaseRate
        };

    }

    public void SetCurrentEquipment(int partsNumber, int fighterNumber)
    {
        //　新しく選択されたパーツのデータをとってきて、currentEquipmentDataというリストを更新
        var newEquipmentData = equipmentDatabaseSOs[partsNumber].equipmentDatabase[fighterNumber];
        currentEquipmentData[partsNumber] = newEquipmentData;
        EquipmentsSaver(partsNumber, fighterNumber);
        SetTotalStates();
        TotalStatesSaver();
    }

    public void SetTotalStates()
    {
        // totalStatesの要素を全て０にする
        for(int i = 0; i < totalStates.Length; i++)
        {
            totalStates[i] = 0;
        }

        //　現在選択中のパーツ(currentEquipmentData)を1つずつ取り出す
        foreach(var equipmentData in currentEquipmentData)
        {
            //　取り出したパーツのすべてのステータスをstatesという配列に代入
            var states = equipmentData.GetStates();
            // statesのから取り出した数字をtotalStatesに加算
            for(int i = 0; i < states.Length; i++)
            {
                totalStates[i] += states[i];
            }
        }
    }

    public EquipmentData GetEquipmentdata(int partsNumber, int fighterNumber)
    {
        var equipmentData = equipmentDatabaseSOs[partsNumber].equipmentDatabase[fighterNumber];
        return equipmentData;
    }

    public int[] CallGetStates(int partsNumber, int fighterNumber)
    {
        var equipmentData = equipmentDatabaseSOs[partsNumber].equipmentDatabase[fighterNumber];
        return equipmentData.GetStates();
    }

    public int[] GetTotalStates()
    {
        return totalStates;
    }

    public EquipmentData[] GetCurrentEquipmentData()
    {
        return currentEquipmentData;
    }
    
    // 値を保存する
    public void EquipmentsSaver(int partsNumber, int fighterNumber)
    {
        switch(partsNumber)
        {
            case (int)EquipmentData.Parts.body:
                PlayerPrefs.SetInt("bodyFighterNumber", fighterNumber);
                break;
            case (int)EquipmentData.Parts.wing:
                PlayerPrefs.SetInt("wingFighterNumber", fighterNumber);
                break;
            case (int)EquipmentData.Parts.thruster:
                PlayerPrefs.SetInt("thrusterFighterNumber", fighterNumber);
                break;
        }

        PlayerPrefs.Save();
    }

    public void TotalStatesSaver()
    {
        PlayerPrefs.SetInt("attack", totalStates[0]);
        PlayerPrefs.SetInt("hp", totalStates[1]);
        PlayerPrefs.SetInt("speed", totalStates[2]);
        PlayerPrefs.SetInt("critRate", totalStates[3]);
        PlayerPrefs.SetInt("critDamage", totalStates[4]);
        PlayerPrefs.SetInt("evasionRate", totalStates[5]);
        PlayerPrefs.SetInt("cTDecreaseRate", totalStates[6]);

        PlayerPrefs.Save();
    }
}

