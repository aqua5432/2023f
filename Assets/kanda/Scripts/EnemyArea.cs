using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵を生成する処理です
public class EnemyArea : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;

    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;

    void Start()
    {
        // ゲーム開始時に、敵オブジェクトを非アクティブ（非表示）にする
        foreach (var enemy in EnemyList)
        {
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        // もし敵が一つも存在しない場合
        if (enemyBox.Length == 0)
        {
            // メインカメラの親を解除し、このエリアを非アクティブ（非表示）にする
            Camera.main.transform.SetParent(null);
            gameObject.SetActive(false);

            // SceneManagerクラスのインスタンスを取得
            var sceneManager = Object.FindObjectOfType<SceneManager>();

            // クリアメッセージを表示
            sceneManager.ShowClear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーオブジェクトがこのエリアに入った場合
        if (other.gameObject.name == "Player")
        {
            // 敵オブジェクトをアクティブ（表示）にする
            foreach (var enemy in EnemyList)
            {
                enemy.SetActive(true);
            }

            // 一度敵を有効化したら、プレイヤーが再びこのエリアに入っても当たり判定を無効にする
            var collider = GetComponent<Collider>();
            collider.enabled = false;
        }
    }
}
