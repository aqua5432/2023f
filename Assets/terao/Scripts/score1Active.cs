using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score1Active : MonoBehaviour
{
    int a = PlayerPrefs.GetInt("Score1");
    void Start ()
    {
        if (a >= 10000)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
