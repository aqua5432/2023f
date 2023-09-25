using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou8 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Enemy");
        if (a >= 20)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
