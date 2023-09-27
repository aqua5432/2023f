using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopToggleController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] PurchaseManager purchaseManager;
    [SerializeField] ShopEquipmentChanger shopEquipmentChanger;
    [SerializeField] ShopStatesDisplayer shopStatesDisplayer;
    [SerializeField] BuyButtonController buyButtonController;
    [SerializeField] StatesManager statesManager;

    [SerializeField] Transform partsGroup;
    [SerializeField] Transform toggles;

    [SerializeField] Toggle toggle;
    [SerializeField] Image image;

    int partsNumber;
    int fighterNumber;

    bool setShopEquipment;

    public void Start()
    {
        //purchasedという、購入済みかどうかを保存しているリストを参照して、購入済みであるもののtoggleのImageにアクセスしたい
        partsNumber = partsGroup.GetSiblingIndex();
        fighterNumber = transform.GetSiblingIndex();

        List<string> keys = purchaseManager.partsKeyLists[partsNumber];

        int wasPerchased = PlayerPrefs.GetInt(keys[fighterNumber]);

        if(wasPerchased == 1)
        {
            Image[] images = toggles.GetChild(fighterNumber).GetComponentsInChildren<Image>();
            foreach(Image image in images)
                image.color = new Color32(100, 100, 200, 100);
        }
    }

    public void OnClickToggle()
    {
        if(toggle.isOn)
        {
            partsNumber = partsGroup.GetSiblingIndex();
            fighterNumber = transform.GetSiblingIndex();
            shopEquipmentChanger.ChangeShopEquipment(partsNumber, fighterNumber);
            statesManager.SetShopEquipmentStates(partsNumber, fighterNumber);
            shopStatesDisplayer.DisplayStates(partsNumber, fighterNumber);
            buyButtonController.DisplayPrice(partsNumber, fighterNumber);
            Debug.Log("partsNumber" + partsNumber);
            Debug.Log("fighterNumber" + fighterNumber);
        }
        DisplayBox();
    }

    public void DisplayBox()
    {
        if(toggle.isOn)
            image.gameObject.SetActive(true);
        else
            image.gameObject.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if(statesManager.setShopEquipment)
        {
            Debug.Log("音ポイントエンター");
            int hoverPartsNumber = partsGroup.GetSiblingIndex();
            int hoverFighterNumber = transform.GetSiblingIndex();

            shopStatesDisplayer.DisplayStatesDiff(hoverPartsNumber, hoverFighterNumber);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(statesManager.setShopEquipment)
        {
            shopStatesDisplayer.DisplayStates(partsNumber, fighterNumber);
        }
    }
}
