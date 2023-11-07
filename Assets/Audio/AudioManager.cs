using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer audioMixer;

    public AudioSource bgmAudioSource;
    public AudioSource seAudioSource;
    public AudioSource voiceAudioSource;

    [SerializeField] List<BGMData> bgmDataList;
    [SerializeField] List<SEData> seDataList;
    [SerializeField] List<VoiceData> voiceDataList;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMData.TITLE tITLE)
    {
        BGMData data = bgmDataList.Find(data => data.tITLE == tITLE);
        bgmAudioSource.clip = data.bgmClip;
        bgmAudioSource.Play();
    }

    public void PauseBGM()
    {
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Pause();
        }
    }

    public void ResumeBGM()
    {
        if (!bgmAudioSource.isPlaying)
        {
            bgmAudioSource.UnPause();
        }
    }
    
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    public bool isSameBGM(BGMData.TITLE tITLE)
    {
        BGMData data = bgmDataList.Find(data => data.tITLE == tITLE);
        bool isSame = bgmAudioSource.clip == data.bgmClip;
        return isSame;
    }

    // ---------------------------------------

    public void PlaySE(SEData.TITLE tITLE)
    {
        SEData data = seDataList.Find(data => data.tITLE == tITLE);
        seAudioSource.PlayOneShot(data.seClip);
    }

    // ---------------------------------------------

    public void PlayVoice(VoiceData.TITLE tITLE)
    {
        VoiceData data = voiceDataList.Find(data => data.tITLE == tITLE);
        voiceAudioSource.PlayOneShot(data.voiceClip);
    }
}

[Serializable]
public class BGMData
{
    public enum TITLE
    {
        Title,
        Home,
        Doutyuu,
        Boss
    }
    public TITLE tITLE;
    public AudioClip bgmClip;
}

[Serializable]
public class SEData
{
    public enum TITLE
    {
        Pause,
        PauseRelease,
        Explosion,
        Warning,
        Selection,
        GunCrit,
        GunNonCrit,
        Gun1,
        Score,
        ScoreRising,
        Drain,
        Barrier,
        BarrierCollapse,
        Beam1,
        DamageReceived,
        Dicision,
        EnemyAttack,
        BulletSetting,
        Evasion,
        Clear,
        Defeat,
        Purchase
    }
    public TITLE tITLE;
    public AudioClip seClip;
}

[Serializable]
public class VoiceData
{
    public enum TITLE
    {
        MainSystemStartup,
        WarningDueToDamage,
        SeventyPercentRemaining,
        FiftyPercentRemaining,
        ThirtyPercentRemaining,
        TenPercentRemaining,
        LargeWeaponChargeComplete,
        EnemyWeekPointFound,
        Barge,
        ContainerConfirmed,
        RequestEvasion,
        MissionCompleted,
        ConfirmDivision,
        ShieldDeployed,
        ConcentrateAttack
    }
    public TITLE tITLE;
    public AudioClip voiceClip;
}
