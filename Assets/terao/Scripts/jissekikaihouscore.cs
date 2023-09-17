using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihouscore : MonoBehaviour
{
    int a = PlayerPrefs.GetInt("Score1");
    // Start is called before the first frame update
    void Start()
    {
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
