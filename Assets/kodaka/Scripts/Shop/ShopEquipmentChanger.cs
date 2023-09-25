using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEquipmentChanger : MonoBehaviour
{
    int equipmentIndex;
    int preEquipmentIndex = 0;

    public void ChangeShopEquipment(int partsNumber, int fighterNumber)
    {
        // 前の装備を非表示にする
        var preEquipment = transform.GetChild(preEquipmentIndex);
        preEquipment.gameObject.SetActive(false);

        // 選択した装備を表示
        equipmentIndex = partsNumber * 7 + fighterNumber;
        var equipment = transform.GetChild(equipmentIndex);
        equipment.gameObject.SetActive(true);

        //　装備を保存
        preEquipmentIndex = equipmentIndex;
    }

    

}
