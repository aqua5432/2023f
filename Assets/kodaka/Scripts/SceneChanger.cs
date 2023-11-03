using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    public void LoadShop()
    {
        SceneManager.LoadScene("Home");
    }

    public void PlaySE()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
