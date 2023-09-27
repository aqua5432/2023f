using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemyArea : MonoBehaviour
{
    // 敵オブジェクトのリストを指定するための変数
    public GameObject[] EnemyList;

    // 敵オブジェクトを格納する一時的な配列
    private GameObject[] enemyBox;

    private bool judge;

    public int bosstype = 0;

    private bool first;

    public int bossnumber = 1;

    private int level1Cleared;
    private int level2Cleared;
    private int level3Cleared;
    private int nowmoney;

    private bool firstClear;

    void Start(){
        // ボス戦BGMを再生
        MyAudioManager.instance.PlayBossBGM();
        firstClear = false;
        first = true;
        judge = true;
    }

    void Update()
    {
        // "Enemy"タグを持つ敵オブジェクトを検索し、配列に格納
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        // もし敵が一つも存在しない場合
        if (enemyBox.Length == 0 && judge)
        {
            if(!firstClear){
                FirstClearJudge();
                var sceneManager = Object.FindObjectOfType<MySceneManager>();
                sceneManager.ShowClear();
                StartCoroutine(Reload());
            }firstClear = true;
        }else if(enemyBox.Length == 1 && first){
            if(bosstype == 1){
                VoiceManager.instance.PlayVoice(7);
            }else{
                VoiceManager.instance.PlayVoice(14);
            }
            first = false;
        }
    }

    private IEnumerator Reload()
    {
        // リロードのアニメーション開始 etc...
        // ２秒待機
        yield return new WaitForSeconds(4.0f);
 
        // 弾を補充
        //Debug.Log("リロード完了");
        SceneManager.LoadScene("Achivement");
    }

    private void FirstClearJudge(){
        if(bossnumber == 1){
            level1Cleared = PlayerPrefs.GetInt("Level1Cleared", 0);
            if(level1Cleared == 0){
                nowmoney = PlayerPrefs.GetInt("possessionCoin", 0);
                nowmoney += 2500;
                PlayerPrefs.SetInt("possessionCoin", nowmoney);
                PlayerPrefs.Save();
            }
            level1Cleared++;
            PlayerPrefs.SetInt("Level1Cleared", level1Cleared);
        }else if(bossnumber == 2){
            level2Cleared = PlayerPrefs.GetInt("Level2Cleared", 0);
            if(level2Cleared == 0){
                nowmoney = PlayerPrefs.GetInt("possessionCoin", 0);
                nowmoney += 2500;
                PlayerPrefs.SetInt("possessionCoin", nowmoney);
                PlayerPrefs.Save();
            }
            level2Cleared++;
            PlayerPrefs.SetInt("Level2Cleared", level2Cleared);
        }else if(bossnumber == 3){
            level3Cleared = PlayerPrefs.GetInt("Level3Cleared", 0);
            if(level3Cleared == 0){
                nowmoney = PlayerPrefs.GetInt("possessionCoin", 0);
                nowmoney += 2500;
                PlayerPrefs.SetInt("possessionCoin", nowmoney);
                PlayerPrefs.Save();
            }
            level3Cleared++;
            PlayerPrefs.SetInt("Level3Cleared", level3Cleared);
        }
        nowmoney = PlayerPrefs.GetInt("possessionCoin", 0);
        nowmoney += 500;
        PlayerPrefs.SetInt("possessionCoin", nowmoney);
        PlayerPrefs.Save();
    }
}
