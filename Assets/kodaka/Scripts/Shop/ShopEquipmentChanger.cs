using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEquipmentChanger : MonoBehaviour
{
    Transform equipment;

    //　なんでもいいから最初適当なやつ入れとく
    [SerializeField]Transform preEquipment;

    public void ChangeShopEquipment(int partsNumber, int fighterNumber)
    {
        // 前の装備を非表示にする
        preEquipment.gameObject.SetActive(false);

        // 選択した装備を表示
        equipment = transform.GetChild(partsNumber).GetChild(fighterNumber);
        equipment.gameObject.SetActive(true);

        //　装備を保存
        preEquipment = equipment;
    }

    

}
