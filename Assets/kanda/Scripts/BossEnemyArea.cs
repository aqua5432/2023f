using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyArea : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;

    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;

    private bool judge = true;

    public int bosstype = 0;

    private bool first = true;

    void Start(){
        // ボス戦BGMを再生
        MyAudioManager.instance.PlayBossBGM();
    }

    void Update()
    {
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        // もし敵が一つも存在しない場合
        if (enemyBox.Length == 0 && judge)
        {
            // メインカメラの親を解除し、このエリアを非アクティブ（非表示）にする
            Camera.main.transform.SetParent(null);
            gameObject.SetActive(false);

            // SceneManagerクラスのインスタンスを取得
            var sceneManager = Object.FindObjectOfType<MySceneManager>();

            // クリアメッセージを表示
            sceneManager.ShowClear();
        }else if(enemyBox.Length == 1 && first){
            if(bosstype == 1){
                VoiceManager.instance.PlayVoice(7);
            }else{
                VoiceManager.instance.PlayVoice(14);
            }
            first = false;
        }
    }
}
