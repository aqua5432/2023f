using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;
    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;
    public GameObject[] dividedenemy;
    private bool judge;

    void Start(){
        judge = true; // 初期状態で分割フラグを有効にする
    }

    void Update(){
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
        // もし敵が一つも存在しない場合かつ分割がまだ行われていない場合
        if (enemyBox.Length == 1 && judge){
            enemydivide(); // 敵の分割を実行
            AudioManager.instance.PlayVoice((VoiceData.TITLE)12); // 音声を再生
            judge = false; // 分割が行われたことを記録
        }
    }

    // 敵の分割を行うメソッド
    public void enemydivide(){
        foreach (GameObject enemy in dividedenemy){
            enemy.SetActive(true); // 分割された敵をアクティブにする
        }
    }
}
