using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    public static MyAudioManager instance; // AudioManagerのインスタンスを静的に保持

    public AudioSource bgmSource; // BGM再生用のAudioSource

    public AudioClip normalBGM; // 通常のBGM
    public AudioClip bossBGM; // ボス戦BGM

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

    // ボス戦BGMを再生するメソッド
    public void PlayBossBGM()
    {
        bgmSource.clip = bossBGM;
        bgmSource.Play();
    }

    // 通常のBGMを再生するメソッド
    public void PlayNormalBGM()
    {
        bgmSource.clip = normalBGM;
        bgmSource.Play();
    }

    // BGMを一時停止するメソッド
    public void PauseBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Pause();
        }
    }

    // BGMを再開するメソッド
    public void ResumeBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.UnPause();
        }
    }
}
