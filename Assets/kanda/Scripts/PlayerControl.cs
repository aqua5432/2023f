using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使うときに書きます。

//主人公機の処理をします
public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public GameObject beam;
    //最大HP。
    int maxHp = 155;
    //現在のHP。
    int currentHp;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        //自動で全進しています
        /*
        transform.position += transform.TransformDirection
        (Vector3.forward * Speed);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        */

        // 上矢印キーが押されたときの処理
        if (Input.GetKey(KeyCode.UpArrow)){
            //上方向に移動+少し傾く
            transform.position += new Vector3(0, 0.1f, 0);
            transform.rotation = Quaternion.Euler(-30, 0, 0);
        }
        // 下矢印キーが押されたときの処理
        if (Input.GetKey(KeyCode.DownArrow)){
            //下方向に移動+少し傾く
            transform.position += new Vector3(0, -0.1f, 0);
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
        // 右矢印キーが押されたときの処理
        if (Input.GetKey(KeyCode.RightArrow)){
            //右方向に移動+少し傾く
            transform.position += new Vector3(0.1f, 0,  0);
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
        // 左矢印キーが押されたときの処理
        if (Input.GetKey(KeyCode.LeftArrow)){
            //左方向に移動+少し傾く
            transform.position += new Vector3(-0.1f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        // Enterキーが押されたときの処理
        if (Input.GetKey(KeyCode.Return)){
            //通常攻撃の実行
            Instantiate(beam.gameObject, this.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
{
    // 衝突したオブジェクトのタグをチェック
    if (other.gameObject.CompareTag("Enemy"))
    {
        // ダメージは1～50の中でランダムに決める。
        int damage = Random.Range(1, 50);
        Debug.Log("damage : " + damage);

        // 現在のHPからダメージを引く
        currentHp -= damage; // 現在のHPからダメージを引く

        // 現在のHPが0未満にならないように制限
        currentHp = Mathf.Max(currentHp, 0);

        Debug.Log("After currentHp : " + currentHp);

        // 最大HPにおける現在のHPをSliderに反映。
        slider.value = (float)currentHp / (float)maxHp;
        Debug.Log("slider.value : " + slider.value);

        other.gameObject.SetActive(false);
        Object.Destroy(other.gameObject); // 当たった敵は削除する

        //Playerの体力が0になったとき
        if(currentHp <= 0)
            {
                //ゲームオーバー画面を出す
                Camera.main.transform.SetParent(null);
                gameObject.SetActive(false);
                var sceneManager = Object.FindObjectOfType<SceneManager>();
                sceneManager.ShowGameOver();
            }
    }
}
}
