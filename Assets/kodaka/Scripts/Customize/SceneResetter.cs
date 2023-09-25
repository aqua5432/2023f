using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneResetter : MonoBehaviour
{
    [SerializeField] List<Transform> toggles;
    [SerializeField] List<int> fighterNumbers;
    [SerializeField] PurchaseManager purchaseManager;

    void Start()
    {
        // partTogglesとfighterNumbersにそれぞれbody,wing,thrusterの順番で値やオブジェクトがアタッチされてることが前提
        // それぞれのトグルのisOnをtrueにして、ToggleControlerのOnClickToggleを呼び出す。
        for(int i = 0; i < toggles.Count; i++)
        {
            Transform part = toggles[i].GetChild(fighterNumbers[i]);
            part.transform.GetComponent<Toggle>().isOn = true;
        }

        // Playerprefsに保存されてる、purchasedの履歴を参照して、トグルのセットアクティブを切り替える
        // １ならtrue 0ならfalse
        List<List<string>> partskeyLists = purchaseManager.partsKeyLists;
        for(int i = 0; i < partskeyLists.Count; i++)
        {
            int partsNumber = i;
            List<string> keys = partskeyLists[i];
            for(int x = 0; x < keys.Count; x++)
            {
                int wasPurchased = PlayerPrefs.GetInt(keys[x]);
                int fighterNumber = x; 
                Transform toggle = toggles[partsNumber].GetChild(fighterNumber);
                if(wasPurchased == 1)
                    toggle.gameObject.SetActive(true);
                else
                    toggle.gameObject.SetActive(false);
                
            }
        }
    }

    
}
