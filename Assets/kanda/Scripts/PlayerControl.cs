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

    public int playerdamage = 15;

    public PauseManager PauseManager;
    public VoiceManager VoiceManager;
    public HelpManager HelpManager;

    public GameObject[] bodys;
    public GameObject[] wings;
    public GameObject[] thrusters;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        //Debug.Log("Start currentHp : " + currentHp);
        reloading = false;
        attackdamage = damageAmount;
        Debug.Log("Before PlayVoice(0)");
        VoiceManager.PlayVoice(0);
        Debug.Log("After PlayVoice(0)");
        PlayerSet();
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
        if (Input.GetKeyDown(KeyCode.W)){
            //上方向に移動+少し傾く
            transform.position += new Vector3(0, 0.1f * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(-30 * Time.deltaTime, 0, 0);
        }
        // 下矢印キーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.S)){
            //下方向に移動+少し傾く
            transform.position += new Vector3(0, -0.1f * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(30 * Time.deltaTime, 0, 0);
        }
        // 右矢印キーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.D)){
            //右方向に移動+少し傾く
            transform.position += new Vector3(0.1f * Time.deltaTime, 0,  0);
            transform.rotation = Quaternion.Euler(0, 0, -30 * Time.deltaTime);
        }
        // 左矢印キーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.A)){
            //左方向に移動+少し傾く
            transform.position += new Vector3(-0.1f * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 30 * Time.deltaTime);
        }
        // Enterキーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.X) && !reloading ){
            //通常攻撃の実行
            Instantiate(beam.gameObject, this.transform.position, Quaternion.identity);
            SEManager.instance.PlaySE(7);
        }
        if (Input.GetMouseButtonDown(0)&& !reloading)
        {
            ShootBeam();
            // リロード開始
            StartCoroutine(Reload());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(barriercount == 0){
                VoiceManager.instance.PlayVoice(13);
                // ゲームオブジェクトの表示状態を切り替える
                barrier.SetActive(true);
                barriercount++;
                SEManager.instance.PlaySE(11);
            }else{
                Debug.Log(barriercount);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Pキーが押されたらポーズする
            PauseManager.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            // Fキーが押されたら再開する
            PauseManager.Resume();
        }if (Input.GetKeyDown(KeyCode.H))
        {
            // Pキーが押されたらポーズする
            PauseManager.Pause();
            HelpManager.ShowNextScreen();
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

            SEManager.instance.PlaySE(13);

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
                SEManager.instance.PlaySE(5);
            }else if(randomdamage>=1 && randomdamage<=3){
                attackdamage = 50;
            }else if(randomdamage>=4 && randomdamage<=24){
                attackdamage+=5;
            }else if(randomdamage>=25 && randomdamage<=74){
                attackdamage-=5;
            }else if(randomdamage>=75){
                attackdamage-=15;
                SEManager.instance.PlaySE(6);
            }
        }else if(count == 3){
            // SceneManagerクラスのインスタンスを取得
            var sceneManager = Object.FindObjectOfType<SceneManager>();
            // スコアを増加（ここでは1000点加算）
            sceneManager.AddScore(100);
            SEManager.instance.PlaySE(9);
        }return attackdamage;
    }

    private void OnTriggerEnter(Collider other){
        // 衝突したオブジェクトのタグをチェック
        if (other.gameObject.CompareTag("EnemyBeam"))
        {
            if(barriercount == 1){
                Debug.Log("barrier");
                barrier.SetActive(false);
                barriercount++;
                SEManager.instance.PlaySE(12);
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
        SEManager.instance.PlaySE(10);
    }

    private void playerHit(Collider other){
        SEManager.instance.PlaySE(14);
        // ダメージは1～50の中でランダムに決める。
        int damage = playerdamage;
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
        float HP = (float)currentHp / (float)maxHp;
        slider.value = HP;
        if(HP < 0.7){
            if(HP < 0.5){
                if(HP < 0.3){
                    if(HP < 0.1){
                        VoiceManager.instance.PlayVoice(5);
                    }
                    VoiceManager.instance.PlayVoice(4);
                }
                VoiceManager.instance.PlayVoice(3);
            }
            VoiceManager.instance.PlayVoice(2);
        }
    }

    public void ChangePlayerDamageForNextWave(int nextdamage){
        playerdamage = nextdamage;
    }

    void PlayerSet(){
        int body = PlayerPrefs.GetInt("bodyFighterNumber",100);
        int wing = PlayerPrefs.GetInt("wingFighterNumber",100);
        int thruster = PlayerPrefs.GetInt("thrusterFighterNumber",100);

        // パーツの非表示
        foreach (GameObject bodyPart in bodys)
        {
            bodyPart.SetActive(false);
        }

        foreach (GameObject wingPart in wings)
        {
            wingPart.SetActive(false);
        }

        foreach (GameObject thrusterPart in thrusters)
        {
            thrusterPart.SetActive(false);
        }

        // 対応するパーツを表示
        if (body >= 0 && body < bodys.Length)
        {
            bodys[body].SetActive(true);
        }else{
            bodys[0].SetActive(true);
        }

        if (wing >= 0 && wing < wings.Length)
        {
            wings[wing].SetActive(true);
        }else{
            wings[0].SetActive(true);
        }

        if (thruster >= 0 && thruster < thrusters.Length)
        {
            thrusters[thruster].SetActive(true);
        }else{
            thrusters[0].SetActive(true);
        }
    }
}
