using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalStatesDisplayer : MonoBehaviour
{
    [SerializeField]
    StatesManager statesManager;

    // Attack、HP、Speedの順で入れないとダメ
    [SerializeField]
    List<TextMeshProUGUI> statesValues;

    public void DisplayTotalStates()
    {
        int[] totalStates = statesManager.GetTotalStates();
        for(int i = 0; i < statesValues.Count; i++)
        {
            statesValues[i].text = totalStates[i].ToString();
        }
    }
}


