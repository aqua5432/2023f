using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score2Active : MonoBehaviour
{
    int b = PlayerPrefs.GetInt("Score2");
    void Start()
    {
        if (b >= 20000)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
