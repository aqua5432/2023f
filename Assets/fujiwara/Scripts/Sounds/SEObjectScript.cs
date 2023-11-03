using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEObjectScript : MonoBehaviour
{
    public static SEObjectScript instance;

    void Awake()
    {
        if(instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }
}
