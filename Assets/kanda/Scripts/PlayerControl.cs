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
    int maxHp = 150;
    //現在のHP。
    int currentHp;
    //Sliderを入れる
    public Slider slider;

    bool reloading;

    public GameObject[] beamPrefabs; // ビームのプレハブ
    public Transform gunTransform; // ビームの発射位置
    public int damageAmount;
    private int count = 0;

    public GameObject barrier;
    private int barriercount = 0;
    private int attackdamage;
    private int attackHealingAmount = 3;
    private int randomdamage = 0;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        //Debug.Log("Start currentHp : " + currentHp);
        reloading = false;
        attackdamage = damageAmount;
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
        if (Input.GetKey(KeyCode.Return) && !reloading ){
            //通常攻撃の実行
            Instantiate(beam.gameObject, this.transform.position, Quaternion.identity);
            // リロード開始
            StartCoroutine(Reload());
        }
        if (Input.GetMouseButtonDown(0)&& !reloading)
        {
            ShootBeam();
            // リロード開始
            StartCoroutine(Reload());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(barriercount == 0){
                // ゲームオブジェクトの表示状態を切り替える
                barrier.SetActive(true);
                barriercount++;
            }else{
                Debug.Log(barriercount);
            }
        }
    }

    void ShootBeam()
    {
        // マウスクリック位置をワールド座標に変換
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;

            GameObject selectedBeamPrefab = beamPrefabs[count];

            // ビームを発射する処理
            GameObject beam = Instantiate(selectedBeamPrefab, gunTransform.position, gunTransform.rotation);
            // ビームの方向を設定
            beam.transform.LookAt(targetPosition);

            // ヒットした敵にダメージを与える
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    attackdamage = ShootBeamChange(count);
                    // ビームのダメージを適用
                    enemy.TakeDamage(attackdamage);
                    attackdamage = damageAmount;
                }
            }
            // 一定時間後にビームを破棄する
            Destroy(beam, 2.0f); // 2.0秒後にビームを破棄

            count++;
            if(count >= beamPrefabs.Length){
                count = 0;
            }
        }
    }

    private int ShootBeamChange(int count){
        if(count == 0){
            attackdamage+=10;
        }else if(count ==1 ){
            attackdamage-=10;
            PlayerHealEffect();
        }else if(count == 2){
            randomdamage = Random.Range(0, 100);
            if(randomdamage == 0){
                attackdamage = 100;
            }else if(randomdamage>=1 && randomdamage<=3){
                attackdamage = 50;
            }else if(randomdamage>=4 && randomdamage<=24){
                attackdamage+=5;
            }else if(randomdamage>=25 && randomdamage<=74){
                attackdamage-=5;
            }else if(randomdamage>=75){
                attackdamage-=15;
            }
        }else if(count == 3){
            // SceneManagerクラスのインスタンスを取得
            var sceneManager = Object.FindObjectOfType<SceneManager>();
            // スコアを増加（ここでは1000点加算）
            sceneManager.AddScore(100);
        }return attackdamage;
    }

    private void OnTriggerEnter(Collider other){
        // 衝突したオブジェクトのタグをチェック
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(barriercount == 1){
                Debug.Log("barrier");
                barrier.SetActive(false);
                barriercount++;
            }else{
                playerHit(other);
            }
        }
    }

    void PlayerHealEffect()
    {// プレイヤーの回復
        currentHp += attackHealingAmount; // count = 1 のビームの回復量を適用
        currentHp = Mathf.Min(currentHp, maxHp); // 現在のHPが最大値を超えないように制限
        UpdateSlider(); // HPバーの更新
    }

    private void playerHit(Collider other){
        // ダメージは1～50の中でランダムに決める。
        int damage = 15;
        //Debug.Log("damage : " + damage);

        // 現在のHPからダメージを引く
        currentHp -= damage; // 現在のHPからダメージを引く

        // 現在のHPが0未満にならないように制限
        currentHp = Mathf.Max(currentHp, 0);

        //Debug.Log("After currentHp : " + currentHp);

        UpdateSlider();
        //Debug.Log("slider.value : " + slider.value);

        other.gameObject.SetActive(false);
        Object.Destroy(other.gameObject); // 当たった敵は削除する

        //Playerの体力が0になったとき
        if(currentHp <= 0){
            //ゲームオーバー画面を出す
            Camera.main.transform.SetParent(null);
            gameObject.SetActive(false);
            var sceneManager = Object.FindObjectOfType<SceneManager>();
            sceneManager.ShowGameOver();
        }
    }

    private IEnumerator Reload()
    {
        // リロードのアニメーション開始 etc...
        //Debug.Log("リロード開始");
        reloading = true;
 
        // ２秒待機
        yield return new WaitForSeconds(1);
 
        // 弾を補充
        //Debug.Log("リロード完了");
        reloading = false;
    }

    void UpdateSlider()
    {// 最大HPにおける現在のHPをSliderに反映。
        slider.value = (float)currentHp / (float)maxHp;
    }
}
