using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSceneResetter : MonoBehaviour
{
    [SerializeField] PurchaseManager purchaseManager;
    [SerializeField] List<GameObject> partsToggles;

    int partsNumber;
    int fighterNumber;

    public bool canPlaySound;

    void Start()
    {
        canPlaySound = false;

        FindUnpurchasedModelNumber();
        SetAsSelectedUnpurchasedModel();

        canPlaySound = true;
    }

    void FindUnpurchasedModelNumber()
    {
        var partsKeyLists = purchaseManager.partsKeyLists;
        for(int i = 0; i < partsKeyLists.Count; i++)
        {
            var partsKeyList = partsKeyLists[i];
            for(int x = 0; x < partsKeyList.Count; x++)
            {
                var partsKey = partsKeyList[x];
                int partsPurchaseValue = PlayerPrefs.GetInt(partsKey);
                if(partsPurchaseValue == 0)
                {
                    partsNumber = i;
                    fighterNumber = x;
                    return;
                }
            }
        } 
    }

    void SetAsSelectedUnpurchasedModel()
    {
        var partToggles = partsToggles[partsNumber];
        var selectedPart = partToggles.transform.GetChild(fighterNumber);
        Toggle selectedPartToggle = selectedPart.GetComponent<Toggle>();
        selectedPartToggle.isOn = true;
    }


}
