using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static BGMScript instance;

    void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
