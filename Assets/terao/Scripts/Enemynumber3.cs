using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemynumber3 : MonoBehaviour
{
    void Start()
    {
        int b = PlayerPrefs.GetInt("Enemy");
        if (b >= 500)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
