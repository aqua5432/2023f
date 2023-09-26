using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        //　ボタン押したら勝手に回転するやつ。初期状態で回ってる
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
            Vector3 drugRotateAngle = -1 * drugRotateSpeed * (Input.mousePosition - prevPos);
            transform.Rotate(new Vector3(0, drugRotateAngle.x, 0), Space.World);
            prevPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotate = true;
            canDrag = false;
        }
    }
}
