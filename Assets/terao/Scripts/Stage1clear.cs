using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1clear : MonoBehaviour
{
    int c = PlayerPrefs.GetInt("Score1");
    // Start is called before the first frame update
    void Start()
    {
        if (c > 0)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
