using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager instance; // SEManagerのインスタンスを静的に保持

    public AudioSource seSource; // 効果音再生用のAudioSource

    public AudioClip[] soundEffects; // 効果音を格納する配列

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 既に存在する場合、重複しないように破棄
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // 効果音を再生するメソッド
    public void PlaySE(int seIndex)
    {
        if (seIndex >= 0 && seIndex < soundEffects.Length)
        {
            // 指定された効果音番号のSEを再生
            seSource.PlayOneShot(soundEffects[seIndex]);
        }
        else
        {
            Debug.LogError("Invalid SE index: " + seIndex);
        }
    }
}
