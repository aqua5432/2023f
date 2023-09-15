using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject shellPrefab;
    private int count;
 
    private GameObject target;

    void Start()
    {
        // 名前でオブジェクトを特定するので一言一句合致させること（ポイント）
        target = GameObject.Find("Player");
        count = Random.Range(0, 200);
    }

    void Update()
    {
        // 「LookAtメソッド」の活用（ポイント）
        this.gameObject.transform.LookAt(target.transform.position);

        count += 1;
 
        // （ポイント）
        // ６０フレームごとに砲弾を発射する
        if(count % 240 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
 
            // 弾速は自由に設定
            shellRb.AddForce(transform.forward * 1000);
 
            // ５秒後に砲弾を破壊する
            Destroy(shell, 1.5f);
            count += Random.Range(0, 50);
        }
    }
}
