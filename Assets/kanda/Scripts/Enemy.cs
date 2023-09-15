using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵のプログラムです
public class Enemy : MonoBehaviour
{
    // 爆発エフェクトのプレハブ（事前に作成されたエフェクトオブジェクト）を指定するための変数
    public GameObject explosion;
    public GameObject damage;

    public float Life = 10;

    // 敵が既に破壊されたかどうかを示すフラグ
    private bool isDestroyed;

    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;

    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;

    private int damagescale = 1;

    private int damagelog = 0;

    void Start(){
        isDestroyed = false;
    }

    void Update(){
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        // もし敵が一つも存在しない場合
        if (enemyBox.Length == 1)
        {
            damagescale = 2;
        }
    }
    // 他のコライダーとの衝突を検出するメソッド
    void OnTriggerEnter(Collider col)
    {
        // 衝突したオブジェクトが"Bullet"（弾丸）のタグを持っており、かつ敵がまだ破壊されていない場合
        if (col.gameObject.tag == "Bullet" && !isDestroyed)
        {
            damagelog = 10 * damagescale;
            Life -= damagelog;
            Instantiate(damage.gameObject, this.transform.position, Quaternion.identity);
            Debug.Log(damagelog);

            if(Life <= 0)
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
    public void TakeDamage(int damageAmount)
    {
        if(!isDestroyed){
            damagelog = damageAmount * damagescale;
            Life -= damagelog;
            Instantiate(damage.gameObject, this.transform.position, Quaternion.identity);
            Debug.Log(damagelog);

            if(Life <= 0)
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
}
