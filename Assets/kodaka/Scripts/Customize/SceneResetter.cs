using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneResetter : MonoBehaviour
{
    [SerializeField] List<Transform> toggles;
    [SerializeField] PurchaseManager purchaseManager;

    List<int> fighterNumberList;

    void Start()
    {
        // partTogglesとfighterNumbersにそれぞれbody,wing,thrusterの順番で値やオブジェクトがアタッチされてることが前提
        // それぞれのトグルのisOnをtrueにして、ToggleControlerのOnClickToggleを呼び出す。
        fighterNumberList = new List<int>
        {
            PlayerPrefs.GetInt("bodyFighterNumber"),
            PlayerPrefs.GetInt("wingFighterNumber"),
            PlayerPrefs.GetInt("thrusterFighterNumber")
        };
        
        for(int i = 0; i < toggles.Count; i++)
        {
            Debug.Log(fighterNumberList[i]);
            Transform part = toggles[i].GetChild(fighterNumberList[i]);
            part.transform.GetComponent<Toggle>().isOn = true;
            
            //　付け焼刃のスクリプト、説明ムズイ
            if(fighterNumberList[i] == 0)
                part.transform.GetComponent<Toggle>().isOn = false;
                part.transform.GetComponent<Toggle>().isOn = true;
        }

        // Playerprefsに保存されてる、purchasedの履歴を参照して、トグルのセットアクティブを切り替える
        //　購入済みのものだけ表示するってこと
        // １なら購入済み　０ならかってない
        List<List<string>> partskeyLists = purchaseManager.partsKeyLists;
        for(int i = 0; i < partskeyLists.Count; i++)
        {
            int partsNumber = i;
            List<string> keys = partskeyLists[i];
            for(int x = 0; x < keys.Count; x++)
            {
                int wasPurchased = PlayerPrefs.GetInt(keys[x]);
                Transform toggle = toggles[partsNumber].GetChild(x);
                if(wasPurchased == 1)
                    toggle.gameObject.SetActive(true);
                else
                    toggle.gameObject.SetActive(false);
                
            }
        }
    }

    
}
