using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossnumber : MonoBehaviour
{
    void Start()
    {
        int b = PlayerPrefs.GetInt("Boss");
        if (b >= 4)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
