using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//通常攻撃の処理です
public class Beam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトが生成されてから1秒後に自動的に破棄される
        Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // ビームを毎フレーム前方に移動させる
        transform.position += transform.TransformDirection(Vector3.forward * 1f);
    }

    // 他のコライダーとの衝突を検出するメソッド
    void OnTriggerEnter(Collider col) {
        // 衝突したオブジェクトが"Enemy"（敵）のタグを持っている場合、このビームオブジェクトを破棄する
        if(col.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
        }
    }
}
