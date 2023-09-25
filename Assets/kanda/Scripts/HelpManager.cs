using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    public GameObject[] helpScreens; // ヘルプ画面の配列
    private int currentScreenIndex = -1; // 現在の画面インデックス

    // 追加：NextボタンとBackボタン
    public GameObject nextButton;
    public GameObject backButton;

    // Fキーを押したときの処理
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CloseHelp();
        }
    }

    public void ShowNextScreen()
    {
        // 次の画面を表示
        if(currentScreenIndex > -1){
            SEManager.instance.PlaySE(15);
        }
        currentScreenIndex++;
        if (currentScreenIndex < helpScreens.Length)
        {
            ShowHelpScreen(currentScreenIndex);
        }
    }

    public void ShowPreviousScreen()
    {
        // 前の画面を表示
        currentScreenIndex--;
        SEManager.instance.PlaySE(15);
        if (currentScreenIndex >= 0)
        {
            ShowHelpScreen(currentScreenIndex);
        }
    }

    private void ShowHelpScreen(int index)
    {
        // 指定されたインデックスのヘルプ画面を表示
        for (int i = 0; i < helpScreens.Length; i++)
        {
            helpScreens[i].SetActive(i == index);
        }

        // 前に戻るボタンを制御
        backButton.SetActive(index > 0);

        // 次に進むボタンを制御
        nextButton.SetActive(index < helpScreens.Length - 1);
    }

    private void CloseHelp()
    {
        // ヘルプ画面を閉じる処理
        foreach (var screen in helpScreens)
        {
            screen.SetActive(false);
        }
        backButton.SetActive(false);
        nextButton.SetActive(false);
        // ボタンを初期状態に戻す
        currentScreenIndex = -1;
    }
}
