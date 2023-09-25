using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEScript : MonoBehaviour
{
    public GameObject ButtonSE;

    public void AudioPlay()
    {
        ButtonSE.GetComponent<AudioSource>().Play();
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
