using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Image aimImage; // 照準器のイメージ
    Vector3 targetPos; // 照準の目標位置

    void Start(){
        AudioManager.instance.PlayVoice(0);
        AudioManager.instance.PlayBGM(BGMData.TITLE.Doutyuu);// ボス戦BGMを再生
    }

    void Update(){
        // マウスの位置に照準器を移動
        transform.position = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)){
            targetPos = hit.point;
            if (hit.transform.CompareTag("Enemy")){
                // 照準器の色を赤に変更（敵をターゲットとしている場合）
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }else{
                // 照準器の色をシアンに変更（敵をターゲットしていない場合）
                aimImage.color = new Color(0f, 1.0f, 1.0f, 1.0f);
            }
        }else{
            // 照準器の色をシアンに変更（何もターゲットしていない場合）
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
