using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        /*
        SEObjectScriptのstatic変数instanceが初期化されていないとエラーが出る。
        このスクリプトをアタッチしたオブジェクトがある、カスタマイズシーンや、ショップシーンから実行するとエラーが出る。
        実際にプレイするときは、これらのシーンに遷移する前に、instanceを初期化するスクリプトがアタッチされているオブジェクトのあるシーンを通るため、
        いったんこのエラーは無視する。
        */
        audioSource = SEObjectScript.instance.GetComponent<AudioSource>();
    }

    public void PlaySE(AudioClip audioClip)
    {
        if(audioSource != null)
            audioSource.PlayOneShot(audioClip);
    }
}
