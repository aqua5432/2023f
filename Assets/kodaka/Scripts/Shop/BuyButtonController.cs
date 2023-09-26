using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BuyButtonController : MonoBehaviour
{
    [SerializeField] StatesManager statesManager;
    [SerializeField] PurchaseManager purchaseManager;

    [SerializeField] TextMeshProUGUI soldOutText;
    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] Button button;

    [SerializeField] List<Transform> toggles;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip purchaseSound;

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

            soldOutText.text = "Sold Out";
            moneyText.text = "";
        } else 
        {
            button.gameObject.SetActive(true);

            price = statesManager.GetEquipmentdata(partsNumber, fighterNumber).GetPrice();
            soldOutText.text = "";
            moneyText.text = string.Format("<color=#000000>{0}</color> / {1}", possessionCoin, price);
            if(possessionCoin < price)
                moneyText.text = string.Format("<color=#FF0000>{0}</color> / {1}", possessionCoin, price);
        }
    }

    public void PurchaseEquipment()
    {
        //　Buyボタンが押された時の処理
        if(possessionCoin >= price)
        {
            audioSource.PlayOneShot(purchaseSound);
            possessionCoin -= price;
            PlayerPrefs.SetInt("possessionCoin", possessionCoin);
            string key = purchaseManager.partsKeyLists[currentPartsNumber][currentFighterNumber];
            PlayerPrefs.SetInt(key, 1);
            DisplayPrice(currentPartsNumber, currentFighterNumber);

            //　購入したパーツに対応するトグルを参照し、イメージカラーを赤にする
            Transform toggle = toggles[currentPartsNumber].GetChild(currentFighterNumber);
            Image[] images = toggle.GetComponentsInChildren<Image>();

            foreach(Image image in images)
                image.color = new Color32(100, 100, 200, 100);

        } else
        {
            
        }
    }
}
