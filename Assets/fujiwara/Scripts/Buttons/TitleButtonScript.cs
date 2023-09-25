using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
        GameObject HB = GameObject.Find("HomeBGM");
        Destroy(HB);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
