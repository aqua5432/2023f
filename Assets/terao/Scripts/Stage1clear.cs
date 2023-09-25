using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1clear : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        int c = PlayerPrefs.GetInt("Boss");
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
