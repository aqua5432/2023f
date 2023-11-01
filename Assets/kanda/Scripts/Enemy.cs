using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIを使用するときに必要なライブラリ

public class Enemy : MonoBehaviour
{
    public GameObject explosion; // 敵破壊時のエフェクト
    public GameObject damage; // ダメージを受けたときのエフェクト
    [SerializeField] int EnemyLife = 50; // 敵の初期ライフ
    [SerializeField] int bossjudge = 1; // ボス敵かどうかを示すフラグ
    private int Life; // 現在のライフ
    private bool isDestroyed; // 敵が破壊されたかどうか
    public GameObject[] EnemyList; // 敵のリスト
    private GameObject[] enemyBox; // 敵の一時的な配列
    private int damagescale; // ダメージスケール
    private int damagelog; // ダメージ履歴
    [SerializeField] int damagescaleamount = 10; // ダメージスケールの増加量
    public Slider slider; // ライフを表示するスライダー
    private int maxHp; // 最大HP
    public PauseManager PauseManager; // ポーズマネージャー
    private bool ShowSlider; // スライダーを表示するかどうかのフラグ

    void Start(){
        isDestroyed = false;
        int difficulty = (int)PlayerPrefs.GetFloat("Difficulty", 1);
        Life = difficulty * EnemyLife;
        damagescale = 1;
        damagelog = 0;
        slider.value = 1;// スライダーを満タンにする
        maxHp = Life;
        // PauseManagerスクリプトを探して参照
        PauseManager = FindObjectOfType<PauseManager>();
    }

    void Update(){
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyBox.Length == 1){
            damagescale = damagescaleamount;
        }if (Input.GetKeyDown(KeyCode.H)){
            slider.gameObject.SetActive(false);
            ShowSlider = false;
        }else if (PauseManager.Restart && !ShowSlider){
            slider.gameObject.SetActive(true);
            ShowSlider = true;
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Bullet" && !isDestroyed){
            TakeDamage(5); // ダメージを与える
        }
    }

    public void TakeDamage(int damageAmount){//ダメージ処理
        if (!isDestroyed){
            damagelog = damageAmount * damagescale;
            Life -= damagelog;
            Instantiate(damage.gameObject, this.transform.position, Quaternion.identity);
            float HP = (float)Life / (float)maxHp;
            slider.value = HP;
        }if (Life <= 0){
            DestroyEnemy();
            UpdateScore();
        }
    }

    private void DestroyEnemy(){//破壊処理
        Instantiate(explosion.gameObject, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        SEManager.instance.PlaySE(2);
        isDestroyed = true;
    }

    private void UpdateScore(){
        var sceneManager = Object.FindObjectOfType<MySceneManager>();
        if (bossjudge == 1){//ボスかどうかの判定(ボスではない)
            sceneManager.AddScore(1000);
            int number = PlayerPrefs.GetInt("Enemy");
            ++number;
            PlayerPrefs.SetInt("Enemy", number);
            PlayerPrefs.Save();
        }else{//ボスの場合
            sceneManager.AddScore(5000);
            int bossnumber = PlayerPrefs.GetInt("Boss");
            ++bossnumber;
            PlayerPrefs.SetInt("Boss", bossnumber);
            PlayerPrefs.Save();
        }
    }
}
