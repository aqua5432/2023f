using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossnumber3 : MonoBehaviour
{
    void Start()
    {
        int b = PlayerPrefs.GetInt("Boss");
        if (b >= 40)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
