using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSceneResetter : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    public void Start()
    {
        toggle.isOn = true;
        Debug.Log("シーンリセッターが呼び出された");
    }
}
