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
    [SerializeField] ShopSceneResetter shopSceneResetter;

    [SerializeField] Transform partsGroup;
    [SerializeField] Transform toggles;

    [SerializeField] Toggle toggle;

    AudioManager audioManager;

    int partsNumber;
    int fighterNumber;

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

        audioManager = AudioManager.instance;
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
            if(shopSceneResetter.canPlaySound == true)
                audioManager.PlaySE(SEData.TITLE.Selection);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(statesManager.setShopEquipment)
        {
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
