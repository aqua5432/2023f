using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ゲームクリアやゲームオーバーを行います
public class MySceneManager : MonoBehaviour
{
    private static MySceneManager instance;
    // スコア表示に関連する変数

    // 現在のスコア
    int _currentScore;

    // プレイヤーが負けたかどうかを判定するフラグ
    bool losejudge;

    public GameObject player; // プレイヤーオブジェクトを指定

    private void Awake()
{
     // 既にインスタンスが存在する場合は自身を破棄
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // シーン遷移時に破棄されないように設定
        DontDestroyOnLoad(gameObject);

        // シーン遷移の間に唯一のインスタンスを保持
        instance = this;

        _currentScore = 0;
        Debug.Log("Score:0");
        losejudge = false;
}


    // ゲームオーバーテキストを表示するメソッド
    public void ShowGameOver()
    {
        // プレイヤーが負けたことを記録
        losejudge = true;

        int nowmoney = PlayerPrefs.GetInt("possessionCoin", 0);
        nowmoney += 500;
        PlayerPrefs.SetInt("possessionCoin", nowmoney);
        PlayerPrefs.Save();

        _currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        int a1 = _currentScore;
        Debug.Log(_currentScore);
        int a2 = PlayerPrefs.GetInt("Score1");
        if(a2<a1){
            PlayerPrefs.DeleteKey("Score1");
            PlayerPrefs.SetInt("Score1",a1);
            PlayerPrefs.Save();
        }MyAudioManager.instance.StopBGM();
        SEManager.instance.PlaySE(20);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.Save();
        StartCoroutine(WaitforBGM());
    }

    private IEnumerator WaitforBGM()
    {
        if (player != null)
        {
            player.SetActive(false);
        }
        // リロードのアニメーション開始 etc...
        // ２秒待機
        yield return new WaitForSeconds(2.0f);
 
        // 弾を補充
        //Debug.Log("リロード完了");
        SceneManager.LoadScene("Achivement");
    }

    // クリアテキストを表示するメソッド
    public void ShowClear()
    {
        // プレイヤーが負けていない場合にのみクリアテキストを表示する
        if (!losejudge)
        {
            _currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
            int a1 = _currentScore;
            Debug.Log(_currentScore);
            int a2 = PlayerPrefs.GetInt("Score1");
            if(a2<a1){
                PlayerPrefs.DeleteKey("Score1");
                PlayerPrefs.SetInt("Score1",a1);
                PlayerPrefs.Save();
            }MyAudioManager.instance.StopBGM();
            SEManager.instance.PlaySE(19);
            PlayerPrefs.SetInt("CurrentScore", 0);
            PlayerPrefs.Save();
        }
    }

    public void AddScore(int score)
    {
    // スコアを加算
    int currentScore = PlayerPrefs.GetInt("CurrentScore", 0); // デフォルト値は0
    Debug.Log(currentScore);
    currentScore += score;
    PlayerPrefs.SetInt("CurrentScore", currentScore);
    PlayerPrefs.Save();
    }
}
