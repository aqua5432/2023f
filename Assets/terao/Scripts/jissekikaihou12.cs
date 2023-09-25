using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou12 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Boss");
        if (a >= 4)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
