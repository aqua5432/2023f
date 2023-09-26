using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{

    List<string> bodyKeyList;
    List<string> wingKeyList;
    List<string> thrusterKeyList;

    public List<List<string>> partsKeyLists;
    
    
    public void Awake()
    {
        // 所持コイン　バトルシーンで受け取れるようになったら消す
        PlayerPrefs.SetInt("possessionCoin", 1250);

        // 初期カスタムを購入済みにする
        PlayerPrefs.SetInt("body0Purchased", 1);
        PlayerPrefs.SetInt("wing0Purchased", 1);
        PlayerPrefs.SetInt("thruster0Purchased", 1);

        
        // 購入履歴をリセットしたいときにコメントアウト外す
        /*
        PlayerPrefs.SetInt("body1Purchased", 0);
        PlayerPrefs.SetInt("body2Purchased", 0);
        PlayerPrefs.SetInt("body3Purchased", 0);
        PlayerPrefs.SetInt("body4Purchased", 0);
        PlayerPrefs.SetInt("body5Purchased", 0);
        PlayerPrefs.SetInt("body6Purchased", 0);

        PlayerPrefs.SetInt("wing1Purchased", 0);
        PlayerPrefs.SetInt("wing2Purchased", 0);
        PlayerPrefs.SetInt("wing3Purchased", 0);
        PlayerPrefs.SetInt("wing4Purchased", 0);
        PlayerPrefs.SetInt("wing5Purchased", 0);
        PlayerPrefs.SetInt("wing6Purchased", 0);

        PlayerPrefs.SetInt("thruster1Purchased", 0);
        PlayerPrefs.SetInt("thruster2Purchased", 0);
        PlayerPrefs.SetInt("thruster3Purchased", 0);
        PlayerPrefs.SetInt("thruster4Purchased", 0);
        PlayerPrefs.SetInt("thruster5Purchased", 0);
        PlayerPrefs.SetInt("thruster6Purchased", 0);
        */

        bodyKeyList = new List<string>
        {
            "body0Purchased",
            "body1Purchased",
            "body2Purchased",
            "body3Purchased",
            "body4Purchased",
            "body5Purchased",
            "body6Purchased"
        };

        wingKeyList = new List<string>
        {
            "wing0Purchased",
            "wing1Purchased",
            "wing2Purchased",
            "wing3Purchased",
            "wing4Purchased",
            "wing5Purchased",
            "wing6Purchased"
        };

        thrusterKeyList = new List<string>
        {
            "thruster0Purchased",
            "thruster1Purchased",
            "thruster2Purchased",
            "thruster3Purchased",
            "thruster4Purchased",
            "thruster5Purchased",
            "thruster6Purchased"
        };

        partsKeyLists = new List<List<string>>
        {
            bodyKeyList,
            wingKeyList,
            thrusterKeyList
        };

        


    }
}
