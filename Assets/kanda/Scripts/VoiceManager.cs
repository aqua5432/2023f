using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager instance; // VoiceManagerのインスタンスを静的に保持

    public AudioSource voiceSource; // 音声再生用のAudioSource

    public AudioClip[] voices; // 音声を格納する配列

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

    // ボイスを再生するメソッド
    public void PlayVoice(int voiceIndex)
    {
        if (voiceIndex >= 0 && voiceIndex < voices.Length)
        {
            // 指定されたボイス番号の音声を再生
            voiceSource.PlayOneShot(voices[voiceIndex]);
        }
        else
        {
            Debug.LogError("Invalid voice index: " + voiceIndex);
        }
    }
}
