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
        //PlayerPrefs.SetInt("possessionCoin", 5000);

        // 初期カスタムを購入済みにする
        PlayerPrefs.SetInt("body0Purchased", 1);
        PlayerPrefs.SetInt("wing0Purchased", 1);
        PlayerPrefs.SetInt("thruster0Purchased", 1);
        
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
