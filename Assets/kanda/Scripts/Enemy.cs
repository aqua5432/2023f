using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵のプログラムです
public class Enemy : MonoBehaviour
{
    // 爆発エフェクトのプレハブ（事前に作成されたエフェクトオブジェクト）を指定するための変数
    public GameObject explosion;

    // 敵が既に破壊されたかどうかを示すフラグ
    private bool isDestroyed = false;

    // 他のコライダーとの衝突を検出するメソッド
    void OnTriggerEnter(Collider col)
    {
        // 衝突したオブジェクトが"Bullet"（弾丸）のタグを持っており、かつ敵がまだ破壊されていない場合
        if (col.gameObject.tag == "Bullet" && !isDestroyed)
        {
            // 爆発エフェクトを指定位置に生成
            Instantiate(explosion.gameObject, this.transform.position, Quaternion.identity);

            // この敵オブジェクトを破棄
            Destroy(this.gameObject);

            // SceneManagerクラスのインスタンスを取得
            var sceneManager = Object.FindObjectOfType<SceneManager>();

            // スコアを増加（ここでは1000点加算）
            sceneManager.AddScore(1000);

            // 一度倒されたフラグをセット
            isDestroyed = true;
        }
    }
}
