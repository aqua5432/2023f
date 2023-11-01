using UnityEngine;

public class HelpUIController : MonoBehaviour
{
    public GameObject[] helpScreen; // ヘルプ画面のGameObject
    public GameObject closeButton; // 閉じるボタンのGameObject
    public GameObject nextButton;
    public GameObject backButton;
    public AudioSource buttonClickSound;
    private int pagecount;

    private void Start(){
        pagecount = 0;
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.F)){// 閉じるボタンがクリックされたときの処理
            helpScreen[pagecount].SetActive(false);
            closeButton.SetActive(false);
            buttonClickSound.Play();
            pagecount = 0;
            nextButton.SetActive(false);
            backButton.SetActive(false);
        }
    }

    public void ShowHelpScreen(){// Helpボタンがクリックされたときの処理
        helpScreen[pagecount].SetActive(true);
        closeButton.SetActive(true);
        buttonClickSound.Play();
        ButtonShowJudge();
    }

    public void CloseHelpScreen(){// 閉じるボタンがクリックされたときの処理
        helpScreen[pagecount].SetActive(false);
        closeButton.SetActive(false);
        nextButton.SetActive(false);
        backButton.SetActive(false);
        buttonClickSound.Play();
        pagecount = 0;
    }

    public void ShowNextHelpScreen(){// Helpボタンがクリックされたときの処理
        helpScreen[pagecount].SetActive(false);
        buttonClickSound.Play();
        pagecount++;
        helpScreen[pagecount].SetActive(true);
        ButtonShowJudge();
    }

    public void ShowBackHelpScreen(){// 閉じるボタンがクリックされたときの処理
        helpScreen[pagecount].SetActive(false);
        buttonClickSound.Play();
        pagecount--;
        helpScreen[pagecount].SetActive(true);
        ButtonShowJudge();
    }

    private void ButtonShowJudge(){
        int index = helpScreen.Length;
        if(index == 1){
            nextButton.SetActive(false);
            backButton.SetActive(false);
        }else{
            // 前に戻るボタンを制御
            backButton.SetActive(pagecount > 0);
            // 次に進むボタンを制御
            nextButton.SetActive(pagecount < index - 1);
        }
    }
}
