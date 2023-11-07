using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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

    AudioManager audioManager;
    [SerializeField] AudioClip selectionSound;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    public void OnClickToggle()
    {
        if(toggle.isOn)
        {
            int partsNumber = partsGroup.GetSiblingIndex();
            int fighterNumber = transform.GetSiblingIndex();
            statesManager.SetCurrentEquipment(partsNumber, fighterNumber);
            equipmentChanger.ChangeEquipment(partsNumber, fighterNumber);
            totalStatesDisplayer.DisplayTotalStates();
            // SceneResetter から呼び出された場合のみ効果音を再生
            if (!SceneResetter.first)
                audioManager.PlaySE(SEData.TITLE.Selection);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int hoverPartsNumber = partsGroup.GetSiblingIndex();
        int hoverFighterNumber = transform.GetSiblingIndex();
        totalStatesDisplayer.DisplayStatesDiff(hoverPartsNumber, hoverFighterNumber);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        totalStatesDisplayer.DisplayTotalStates();
    }
}
    
