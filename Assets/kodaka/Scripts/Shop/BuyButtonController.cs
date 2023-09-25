using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BuyButtonController : MonoBehaviour
{
    [SerializeField] StatesManager statesManager;
    [SerializeField] PurchaseManager purchaseManager;

    [SerializeField] TextMeshProUGUI possessionCoinText;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] Button button;

    [SerializeField] List<Transform> toggles;

    int currentPartsNumber;
    int currentFighterNumber;

    int possessionCoin;
    int price;

    public void DisplayPrice(int partsNumber, int fighterNumber)
    {

        possessionCoin = PlayerPrefs.GetInt("possessionCoin");
        //購入済みなら１，まだ買ってなければ０
        string key = purchaseManager.partsKeyLists[partsNumber][fighterNumber];
        int wasPerchased = PlayerPrefs.GetInt(key);

        currentPartsNumber = partsNumber;
        currentFighterNumber = fighterNumber;
        
        if(wasPerchased == 1)
        {
            button.gameObject.SetActive(false);
            possessionCoinText.text = "sold out";
            possessionCoinText.color = Color.white;
            priceText.text = "";
        } else 
        {
            button.gameObject.SetActive(true);
            price = statesManager.GetEquipmentdata(partsNumber, fighterNumber).GetPrice();
            priceText.text = string.Format("/ {0}", price);
            possessionCoinText.text = possessionCoin.ToString();
            if(possessionCoin < price)
                possessionCoinText.color = Color.red;
        }
    }

    public void PurchaseEquipment()
    {
        //　プライス弾くぽっせっしょんこいｎ
        if(possessionCoin >= price)
        {
            possessionCoin -= price;
            PlayerPrefs.GetInt("possessionCoin", possessionCoin);
            string key = purchaseManager.partsKeyLists[currentPartsNumber][currentFighterNumber];
            PlayerPrefs.SetInt(key, 1);
            DisplayPrice(currentPartsNumber, currentFighterNumber);

            //　購入したパーツに対応するトグルを参照し、イメージカラーを赤にする
            Transform toggle = toggles[currentPartsNumber].GetChild(currentFighterNumber);
            Image[] images = toggle.GetComponentsInChildren<Image>();

            foreach(Image image in images)
                image.color = new Color32(255, 255, 255, 75);

        } else
        {
            
        }
    }
}
