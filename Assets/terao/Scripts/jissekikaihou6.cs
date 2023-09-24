using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou6 : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Score1");
        if (a >= 500000)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
