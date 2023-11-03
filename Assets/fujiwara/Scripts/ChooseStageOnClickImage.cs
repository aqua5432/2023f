using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChooseStageOnClickImage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject boxes;
    int siblingIndex;

    [SerializeField] SEScript sEScript;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        siblingIndex = transform.GetSiblingIndex();
        int childCount = boxes.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            var box = boxes.transform.GetChild(i);
            if(i == siblingIndex)
            {
                box.gameObject.SetActive(true);
                sEScript.AudioPlay();
            }
            else
                box.gameObject.SetActive(false);
        }
    }
}
