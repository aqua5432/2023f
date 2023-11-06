using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics;

public class FighterDisplayer : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    bool isRotate = true;

    [SerializeField] MouseOverChecker mouseOverChecker;
    [SerializeField] float drugRotateSpeed;
    bool canDrag;
    Vector3 prevPos;


    public void Update()
    {
        if(isRotate)
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0), Space.World);
        }


        if (Input.GetMouseButtonDown(0) && mouseOverChecker.isMouseOver)
        {
            isRotate = false;
            canDrag = true;
            prevPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && canDrag)
        {
            Vector3 drugRotateAngle = drugRotateSpeed * (Input.mousePosition - prevPos);

            // 横回転
            transform.Rotate(new Vector3(0, -1 * drugRotateAngle.x, 0), Space.World);
            // 縦回転
            transform.Rotate(new Vector3(drugRotateAngle.y, 0, 0));

            // 縦回転角度制限
            Vector3 eulerAngeles = transform.eulerAngles;
            if(eulerAngeles.x > 180)
            {
                eulerAngeles.x -= 360;
            }
            eulerAngeles.x = Mathf.Clamp(eulerAngeles.x, -45, 45);
            transform.eulerAngles = eulerAngeles;

            // 早く動かすとz軸で回転しちゃうときがあるため
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                0
            );


            prevPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotate = true;
            canDrag = false;
        }
    }
}
