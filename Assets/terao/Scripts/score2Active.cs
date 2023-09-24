using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score2Active : MonoBehaviour
{
    
    void Start()
    {
        int b = PlayerPrefs.GetInt("Score1");
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
