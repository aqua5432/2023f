using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEScript : MonoBehaviour
{
    public void AudioPlay()
    {
        SEObjectScript.instance.GetComponent<AudioSource>().Play();
    }
}
