using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float forwardSpeed = 20;

    void Start()
    {
        
    }


    void Update()
    {
        //自機と同じ速度で勝手に前進
        Vector3 forward = transform.position;
        forward.z += forwardSpeed * Time.deltaTime;
        transform.position = forward;
    }
}
