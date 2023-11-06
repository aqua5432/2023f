using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChooseStageOnClickImage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] BoxScript boxScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        int siblingIndex = transform.GetSiblingIndex();
        boxScript.st = siblingIndex;

        boxScript.DisplayBox();
    }
}
