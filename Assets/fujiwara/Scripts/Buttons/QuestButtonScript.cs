using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestButtonScript : MonoBehaviour
{
    public void OnClickQuestButton()
    {
        SceneManager.LoadScene("Quest");
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
