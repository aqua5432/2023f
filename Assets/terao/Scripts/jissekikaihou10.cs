using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou10 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Enemy");
        if (a >= 100)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
