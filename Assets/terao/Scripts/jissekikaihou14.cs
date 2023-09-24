using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou14 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Boss");
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
