using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionButtonScript : MonoBehaviour
{
    public void OnClickMissionButton()
    {
        SceneManager.LoadScene("Mission");
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
