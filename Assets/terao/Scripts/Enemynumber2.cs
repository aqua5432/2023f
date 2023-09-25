using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemynumber2 : MonoBehaviour
{
    void Start()
    {
        int b = PlayerPrefs.GetInt("Enemy");
        if (b >= 100)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
