using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jissekikaihou1 : MonoBehaviour
{
    int a = PlayerPrefs.GetInt("Score1");
    // Start is called before the first frame update
    void Start()
    {
        if (a>0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
