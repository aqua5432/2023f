using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ゲームクリアやゲームオーバーを行います
public class MySceneManager : MonoBehaviour
{
    // ゲームオーバーテキストの表示に関連する変数
    public Text GameOverText;

    // クリアテキストの表示に関連する変数
    public Text ClearText;

    // スコア表示に関連する変数
    public Text ScoreText;

    // 現在のスコア
    int _currentScore = 0;

    // プレイヤーが負けたかどうかを判定するフラグ
    bool losejudge = false;

    private void Start()
    {
        // ゲーム開始時に実行される初期化処理

        // ゲームオーバーテキストを非表示にする
        GameOverText.gameObject.SetActive(false);

        // クリアテキストを非表示にする
        ClearText.gameObject.SetActive(false);

        // スコアテキストに初期スコアを表示する
        ScoreText.text = _currentScore.ToString();
    }

    // ゲームオーバーテキストを表示するメソッド
    public void ShowGameOver()
    {
        // プレイヤーが負けたことを記録
        losejudge = true;

        // ゲームオーバーテキストを表示する
        GameOverText.gameObject.SetActive(true);
        int a1 = _currentScore;
        Debug.Log(_currentScore);
        int a2 = PlayerPrefs.GetInt("Score1");
        if(a2<a1){
            PlayerPrefs.DeleteKey("Score1");
            PlayerPrefs.SetInt("Score1",a1);
            PlayerPrefs.Save();
        }
    }

    // クリアテキストを表示するメソッド
    public void ShowClear()
    {
        // プレイヤーが負けていない場合にのみクリアテキストを表示する
        if (!losejudge)
        {
            ClearText.gameObject.SetActive(true);
            int a1 = _currentScore;
            Debug.Log(_currentScore);
            int a2 = PlayerPrefs.GetInt("Score1");
            if(a2<a1){
                PlayerPrefs.DeleteKey("Score1");
                PlayerPrefs.SetInt("Score1",a1);
                PlayerPrefs.Save();
            }
        }
    }

    // スコアを加算し、表示するメソッド
    public void AddScore(int score)
    {
        // スコアを加算
        _currentScore += score;

        // スコアをテキストに表示
        ScoreText.text = _currentScore.ToString();
    }
}
