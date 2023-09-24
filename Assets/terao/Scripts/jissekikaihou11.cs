using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou11 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Enemy");
        if (a >= 500)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
