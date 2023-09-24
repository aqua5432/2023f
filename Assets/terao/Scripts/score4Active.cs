using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score4Active : MonoBehaviour
{
    void Start()
    {
        int a = PlayerPrefs.GetInt("Score1");
        if (a >= 100000)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
