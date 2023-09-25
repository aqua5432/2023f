using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneResetter : MonoBehaviour
{
    [SerializeField] List<Transform> Toggles;
    [SerializeField] List<int> fighterNumbers;
    [SerializeField] PurchaseManager purchaseManager;

    void Start()
    {
        // partTogglesとfighterNumbersにそれぞれbody,wing,thrusterの順番で値やオブジェクトがアタッチされてることが前提
        // それぞれのトグルのisOnをtrueにして、ToggleControlerのOnClickToggleを呼び出す。
        for(int i = 0; i < Toggles.Count; i++)
        {
            Transform part = Toggles[i].GetChild(fighterNumbers[i]);
            part.transform.GetComponent<Toggle>().isOn = true;
        }

        // Playerprefsに保存されてる、purchasedの履歴を参照して、トグルのセットアクティブを切り替える
        // １ならtrue 0ならfalse
    }

    
}
