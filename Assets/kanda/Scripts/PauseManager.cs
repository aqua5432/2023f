using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 追加: UnityEngine.UI名前空間をインポート

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject playercanvas;

    public void Pause()
    {
        Time.timeScale = 0;
        SEManager.instance.PlaySE(0);
        pausePanel.SetActive(true);
        playercanvas.SetActive(false);

        // BGMを停止
        MyAudioManager.instance.PauseBGM();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        SEManager.instance.PlaySE(1);
        pausePanel.SetActive(false);
        playercanvas.SetActive(true);

        // BGMを再開
        MyAudioManager.instance.ResumeBGM();
    }
}
