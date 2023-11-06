using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleButtonScript : MonoBehaviour
{
    [SerializeField] BGMScript bGMScript;

    private BoxScript boxscript;

    public void OnClickBattleButton()
    {
        GameObject HB = GameObject.Find("HomeBGM");
        Destroy(HB);
        
        this.boxscript = FindObjectOfType<BoxScript>();
        if(boxscript.st == 0)
        {
            SceneManager.LoadScene("1-1");
        }
        else if (boxscript.st == 1)
        {
            SceneManager.LoadScene("1-2");
        }
        else
        {
            SceneManager.LoadScene("1-3");
        }

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
