using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou7 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Score1");
        if (a >= 800000)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
