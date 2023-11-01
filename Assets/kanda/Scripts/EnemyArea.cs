using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵を生成する処理を担当するクラス
public class EnemyArea : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;
    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;
    public GameObject BossEnemy;
    private bool BossStart;
    private PlayerControl playerControl; // PlayerControlスクリプトへの参照
    public int nextdamage = 15; // 次の敵の波でプレイヤーが受けるダメージ
    private bool first;//初めて敵が一体になった

    void Start(){
        // PlayerControlスクリプトへの参照を取得
        playerControl = FindObjectOfType<PlayerControl>();
        BossStart = false;
        first = true;
    }

    void Update(){
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
        // もし敵が一つも存在しない場合かつボスがまだ始まっていない場合
        if (enemyBox.Length == 0 && !BossStart){
            // 新しい敵が生成されるときにプレイヤーが受けるダメージを変更
            playerControl.ChangePlayerDamageForNextWave(nextdamage);
            // ボス敵をアクティブにする
            BossEnemy.SetActive(true);
            BossStart = true;
        } else if (enemyBox.Length == 1 && first) {
            VoiceManager.instance.PlayVoice(14);
            first = false;
        }
    }
}
