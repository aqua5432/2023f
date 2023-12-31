using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject shellPrefab;
    private int count;
 
    private GameObject target;
    public int attacktime = 240;

    void Start()
    {
        // 名前でオブジェクトを特定するので一言一句合致させること（ポイント）
        target = GameObject.Find("Player");
        count = Random.Range(0, 200);
    }

    void Update()
    {
        // ポーズ中はカウントが進まないようにする
        if (Time.timeScale == 0){
            return;
        }
        // 「LookAtメソッド」の活用（ポイント）
        this.gameObject.transform.LookAt(target.transform.position);

        count += 1;
 
        // （ポイント）
        // ６０フレームごとに砲弾を発射する
        if(count % attacktime == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            AudioManager.instance.PlaySE((SEData.TITLE)16);
            // 弾速は自由に設定
            shellRb.AddForce(transform.forward * 1000);
 
            // ５秒後に砲弾を破壊する
            Destroy(shell, 1.5f);
            count += Random.Range(0, 50);
        }
    }
}
