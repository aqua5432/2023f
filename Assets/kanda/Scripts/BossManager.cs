using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;
    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;
    private bool judge;

    void Start(){
        judge = true; // 初期状態で判定フラグを有効にする
    }

    void Update(){
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
        // もし敵が一つも存在しない場合かつ判定がまだ行われていない場合
        if (enemyBox.Length == 1 && judge){
            Destroy(this.gameObject); // このオブジェクトを破棄
            judge = false; // 判定が行われたことを記録
        }
    }
}
