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
    private bool judge = true;

    void Update()
    {
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        // もし敵が一つも存在しない場合
        if (enemyBox.Length == 1 && judge)
        {
            enemydivide();
            judge = false;
        }
    }

    public void enemydivide(){
        foreach (GameObject enemy in dividedenemy){
            enemy.SetActive(true);
        }
    }
}
