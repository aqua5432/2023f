using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemynumber : MonoBehaviour
{
    void Start()
    {
        int b = PlayerPrefs.GetInt("Enemy");
        if (b >= 20)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
