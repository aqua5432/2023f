using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵を生成する処理です
public class EnemyArea : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;

    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;

    public GameObject BossEnemy;

    private bool BossStart = false;

    private PlayerControl playerControl; // PlayerControlスクリプトへの参照

    public int nextdamage = 15;

    void Start()
    {
        // PlayerControlスクリプトへの参照を取得
        playerControl = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        // もし敵が一つも存在しない場合
        if (enemyBox.Length == 0 && !BossStart)
        {
            // 新しい敵が生成されるときにプレイヤーの受けるダメージを変更
            playerControl.ChangePlayerDamageForNextWave(nextdamage);
            
            // ボス敵をアクティブにする
            BossEnemy.SetActive(true);
            BossStart = true;
        }
    }
}
