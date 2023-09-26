using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeFighterDisplayer : MonoBehaviour
{
    List<int> fighterNumberList;

    void Start()
    {
        fighterNumberList = new List<int>
        {
            PlayerPrefs.GetInt("bodyFighterNumber"),
            PlayerPrefs.GetInt("wingFighterNumber"),
            PlayerPrefs.GetInt("thrusterFighterNumber")
        };

        for(int i = 0; i < fighterNumberList.Count; i++)
        {
            transform.GetChild(i).GetChild(fighterNumberList[i]).gameObject.SetActive(true);
        }
    }
}
