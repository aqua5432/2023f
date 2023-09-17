using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FighterDisplayer : MonoBehaviour
{
    bool isRotate = false;
    public float rotateSpeed;

    public MouseOverChecker mouseOverChecker;
    public float drugRotateSpeed;
    bool canRotate;
    Vector3 prevPos;

    public Toggle toggle;

    public void Update()
    {
        if (isRotate)
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0), Space.World);
        }

        if (Input.GetMouseButtonDown(0) && mouseOverChecker.isMouseOver)
        {
            prevPos = Input.mousePosition;
            canRotate = true;
        }

        if (Input.GetMouseButton(0) && canRotate)
        {
            Vector3 drugRotateAngle = -1 * drugRotateSpeed * (Input.mousePosition - prevPos);
            transform.Rotate(new Vector3(0, drugRotateAngle.x, 0), Space.World);
            prevPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            canRotate = false;
        }
    }

    public void ToggleRotate()
    {
        isRotate = toggle.isOn;
    }
}
