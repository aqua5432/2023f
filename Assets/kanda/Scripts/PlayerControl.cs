using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour//主人公機の処理をします
{
    public float Speed;
    public GameObject beam;
    private int maxHp;//最大HP。
    private int currentHp;//現在のHP。
    public Slider slider;
    bool reloading;
    public GameObject[] beamPrefabs; // ビームのプレハブ
    public Transform gunTransform; // ビームの発射位置
    public int damageAmount;
    private int count;
    public GameObject barrier;
    private int barriercount;
    private int attackdamage;
    private int randomdamage;
    public int playerdamage = 10;
    public PauseManager PauseManager;
    public HelpManager HelpManager;
    public GameObject[] bodys;
    public GameObject[] wings;
    public GameObject[] thrusters;
    private int attack;//攻撃力
    private int hp;//体力
    private int speed;//スピード
    private int critRate;//会心率
    private int critDamage;//会心ダメージ上昇率
    private int evasionRate;//回避率
    private int cTDecreaseRate;//クールタイム減少率
    private int difficulty;

    void Start()
    {
        count = 0;
        barriercount = 0;
        randomdamage = 0;
        maxHp = 60;
        attack = PlayerPrefs.GetInt("attack", 0);
        hp = PlayerPrefs.GetInt("hp", 0);
        speed = PlayerPrefs.GetInt("speed", 0);
        critRate = PlayerPrefs.GetInt("critRate", 0);
        critDamage = PlayerPrefs.GetInt("critDamage", 0);
        evasionRate = PlayerPrefs.GetInt("evasionRate", 0);
        cTDecreaseRate = PlayerPrefs.GetInt("cTDecreaseRate", 0);
        damageAmount+=attack;
        int plus = 30*hp;
        maxHp+=plus;
        difficulty = (int)PlayerPrefs.GetFloat("Difficulty", 1);
        slider.value = 1;//Sliderを満タンにする。
        currentHp = maxHp;//現在のHPを最大HPと同じに。
        reloading = false;
        attackdamage = damageAmount;  
        PlayerSet();
    }
    
    void Update()
    {
        // Enterキーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.X) && !reloading ){//通常攻撃の実行
            Instantiate(beam.gameObject, this.transform.position, Quaternion.identity);
            AudioManager.instance.PlaySE((SEData.TITLE)7);
        }if (Input.GetMouseButtonDown(0)&& !reloading){
            ShootBeam();
            StartCoroutine(Reload());// リロード開始
        }if (Input.GetKeyDown(KeyCode.B)){
            if(barriercount == 0){
                AudioManager.instance.PlayVoice((VoiceData.TITLE)13);
                barrier.SetActive(true);
                barriercount++;
                AudioManager.instance.PlaySE((SEData.TITLE)11);
            }else{
                Debug.Log(barriercount);
            }
        }
        if (Input.GetKeyDown(KeyCode.P)){// Pキーが押されたらポーズする
            PauseManager.Pause();
        }if (Input.GetKeyDown(KeyCode.H)){// Hキーが押されたらポーズする
            PauseManager.Pause();
            HelpManager.ShowNextScreen();
        }if (Input.GetKeyDown(KeyCode.Alpha1)){// 数字キー1から4が押されたときにビームの種類を切り替える
            count = 0;
            AudioManager.instance.PlaySE((SEData.TITLE)17);
        }else if (Input.GetKeyDown(KeyCode.Alpha2)){
            count = 1;
            AudioManager.instance.PlaySE((SEData.TITLE)17);
        }else if (Input.GetKeyDown(KeyCode.Alpha3)){
            count = 2;
            AudioManager.instance.PlaySE((SEData.TITLE)17);
        }else if (Input.GetKeyDown(KeyCode.Alpha4)){
            count = 3;
            AudioManager.instance.PlaySE((SEData.TITLE)17);
        }
    }

    void ShootBeam(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// マウスクリック位置をワールド座標に変換
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            Vector3 targetPosition = hit.point;
            GameObject selectedBeamPrefab = beamPrefabs[count];
            // ビームを発射する処理
            GameObject beam = Instantiate(selectedBeamPrefab, gunTransform.position, gunTransform.rotation);
            // ビームの方向を設定
            beam.transform.LookAt(targetPosition);
            AudioManager.instance.PlaySE((SEData.TITLE)13);
            // ヒットした敵にダメージを与える
            if (hit.collider.CompareTag("Enemy")){
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null){
                    attackdamage = ShootBeamChange(count);
                    enemy.TakeDamage(attackdamage);// ビームのダメージを適用
                    attackdamage = damageAmount;
                }
            }
            Destroy(beam, 2.0f); // 2.0秒後にビームを破棄
        }
    }

    private int ShootBeamChange(int count){
        if(count == 0){
            attackdamage+=10;
        }else if(count ==1 ){
            attackdamage-=10;
            PlayerHealEffect(attackdamage);
        }else if(count == 2){
            randomdamage = Random.Range(0, 100 - critRate);
            if(randomdamage == 0){
                attackdamage = 100+critDamage;
                AudioManager.instance.PlaySE((SEData.TITLE)5);
            }else if(randomdamage>=1 && randomdamage<=3){
                attackdamage = 50+(critDamage/2);
            }else if(randomdamage>=4 && randomdamage<=24){
                attackdamage+=5;
            }else if(randomdamage>=25 && randomdamage<=74){
                attackdamage-=5;
            }else if(randomdamage>=75){
                attackdamage-=15;
                AudioManager.instance.PlaySE((SEData.TITLE)6);
            }
        }else if(count == 3){
            var sceneManager = Object.FindObjectOfType<MySceneManager>();
            sceneManager.AddScore(100);
            AudioManager.instance.PlaySE((SEData.TITLE)9);
        }return attackdamage;
    }

    private void OnTriggerEnter(Collider other){
        // 衝突したオブジェクトのタグをチェック
        if (other.gameObject.CompareTag("EnemyBeam")){
            if(barriercount == 1){
                barrier.SetActive(false);
                barriercount++;
                AudioManager.instance.PlaySE((SEData.TITLE)12);
            }else{
                randomdamage = Random.Range(0, 100 - critRate);
                if(randomdamage < evasionRate){
                    AudioManager.instance.PlaySE((SEData.TITLE)18);
                }else{
                    playerHit(other);
                }
            }
        }
    }

    void PlayerHealEffect(int attackdamage){// プレイヤーの回復
        currentHp += attackdamage/2; // count = 1 のビームの回復量を適用
        currentHp = Mathf.Min(currentHp, maxHp); // 現在のHPが最大値を超えないように制限
        UpdateSlider(); // HPバーの更新
        AudioManager.instance.PlaySE((SEData.TITLE)10);
    }

    private void playerHit(Collider other){
        AudioManager.instance.PlaySE((SEData.TITLE)14);
        int damage = playerdamage * difficulty;
        currentHp -= damage; // 現在のHPからダメージを引く
        currentHp = Mathf.Max(currentHp, 0);// 現在のHPが0未満にならないように制限
        UpdateSlider();
        other.gameObject.SetActive(false);
        Object.Destroy(other.gameObject); // 当たった敵は削除する
        //Playerの体力が0になったとき
        if(currentHp <= 0){
            var sceneManager = Object.FindObjectOfType<MySceneManager>();
            sceneManager.ShowGameOver();
        }
    }

    private IEnumerator Reload(){//弾の補充
        reloading = true;
        yield return new WaitForSeconds(5 - (cTDecreaseRate/2));
        reloading = false;
    }

    void UpdateSlider(){// 最大HPにおける現在のHPをSliderに反映。
        float HP = (float)currentHp / (float)maxHp;
        slider.value = HP;
        if(HP < 0.7){
            if(HP < 0.5){
                if(HP < 0.3){
                    if(HP < 0.1){
                        AudioManager.instance.PlayVoice((VoiceData.TITLE)5);
                    }else{
                        AudioManager.instance.PlayVoice((VoiceData.TITLE)4);
                    }
                }else{
                    AudioManager.instance.PlayVoice((VoiceData.TITLE)3);
                }
            }else{
                AudioManager.instance.PlayVoice((VoiceData.TITLE)2);
            }
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
        foreach (GameObject bodyPart in bodys){
            bodyPart.SetActive(false);
        }foreach (GameObject wingPart in wings){
            wingPart.SetActive(false);
        }foreach (GameObject thrusterPart in thrusters){
            thrusterPart.SetActive(false);
        }
        // 対応するパーツを表示
        if (body >= 0 && body < bodys.Length){
            bodys[body].SetActive(true);
        }else{
            bodys[0].SetActive(true);
        }

        if (wing >= 0 && wing < wings.Length){
            wings[wing].SetActive(true);
        }else{
            wings[0].SetActive(true);
        }

        if (thruster >= 0 && thruster < thrusters.Length){
            thrusters[thruster].SetActive(true);
        }else{
            thrusters[0].SetActive(true);
        }
    }
}
