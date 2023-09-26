using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] StatesManager statesManager;
    [SerializeField] EquipmentChanger equipmentChanger;
    [SerializeField] TotalStatesDisplayer totalStatesDisplayer;

    [SerializeField] Transform partsGroup;

    [SerializeField] Toggle toggle;
    [SerializeField] Image image;

    public void OnClickToggle()
    {
        if(toggle.isOn)
        {
            int partsNumber = partsGroup.GetSiblingIndex();
            int fighterNumber = transform.GetSiblingIndex();
            statesManager.SetCurrentEquipment(partsNumber, fighterNumber);
            equipmentChanger.ChangeEquipment(partsNumber, fighterNumber);
            totalStatesDisplayer.DisplayTotalStates();
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
        int hoverPartsNumber = this.transform.parent.parent.parent.GetSiblingIndex();
        int hoverFighterNumber = this.transform.GetSiblingIndex();
        totalStatesDisplayer.DisplayStatesDiff(hoverPartsNumber, hoverFighterNumber);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        totalStatesDisplayer.DisplayTotalStates();
    }
}
    
