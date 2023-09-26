using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    
    
    public void Nextscene()
    {

        Invoke("scene", 0.5f);
    }
    void scene()
    {
        SceneManager.LoadScene("Home");
    }
}
