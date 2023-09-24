using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihouscore : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        int a = PlayerPrefs.GetInt("Score1");
        if (a >= 10000)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
