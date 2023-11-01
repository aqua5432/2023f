using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 追加: UnityEngine.UI名前空間をインポート

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // ポーズ画面のパネル
    public GameObject playercanvas; // プレイヤーUIキャンバス
    public bool Restart; // リスタートフラグ

    public void Pause(){
        Time.timeScale = 0; // ゲーム時間を停止
        SEManager.instance.PlaySE(0); // SE再生（0番のSE）
        pausePanel.SetActive(true); // ポーズ画面を表示
        playercanvas.SetActive(false); // プレイヤーUIを非表示
        Restart = false; // リスタートフラグを無効にする
        // BGMを停止
        MyAudioManager.instance.PauseBGM();
    }

    public void Resume(){
        Time.timeScale = 1; // ゲーム時間を再開
        SEManager.instance.PlaySE(1); // SE再生（1番のSE）
        pausePanel.SetActive(false); // ポーズ画面を非表示
        playercanvas.SetActive(true); // プレイヤーUIを表示
        Restart = true; // リスタートフラグを有効にする
        // BGMを再開
        MyAudioManager.instance.ResumeBGM();
    }
}
