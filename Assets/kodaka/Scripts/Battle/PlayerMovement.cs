using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //　移動量と移動スピード
    Vector3 movePos;
    public float forwardSpeed = 20;
    public float movePosSpeed = 15;

    //　移動限界距離
    public float maxPosX = 30;
    public float maxPosY = 20;

    //　回転量と回転スピード
    Vector3 moveRot;
    public float moveRotSpeed = 90;

    //　回転限界角度
    public float maxRotX = 30;
    public float maxRotZ = 15;

    public float rotationSmoothing = 3;

    void Start()
    {
        
    }

    void Update()
    {
        //　勝手に前進
        Vector3 forward = transform.position;
        forward.z += forwardSpeed * Time.deltaTime;
        transform.position = forward;

        //　勝手に前方向に向くやつ
        Quaternion endRotation = Quaternion.Euler(Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, rotationSmoothing * Time.deltaTime);

        // 移動
        movePos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        movePos *= movePosSpeed * Time.deltaTime;
        transform.Translate(movePos, Space.World);

        // 移動範囲制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -maxPosX, maxPosX);
        pos.y = Mathf.Clamp(pos.y, -maxPosY, maxPosY);
        transform.position = pos;

        // 回転
        moveRot = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        moveRot *= -1 *moveRotSpeed * Time.deltaTime;
        transform.Rotate(moveRot, Space.World);

        // 回転角度制限
        Vector3 eulerRot = transform.eulerAngles;
        // 角度を-maxX ～ maxXで書けるようにするための調整
        if (eulerRot.x > 180)
        {
            eulerRot.x -= 360;
        } 
        if (eulerRot.z > 180)
        {
            eulerRot.z -= 360;
        }
        eulerRot.x = Mathf.Clamp(eulerRot.x, -maxRotX, maxRotX);
        eulerRot.z = Mathf.Clamp(eulerRot.z, -maxRotZ, maxRotZ);
        transform.rotation = Quaternion.Euler(eulerRot);
    }
}