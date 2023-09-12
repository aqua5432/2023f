using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterDisplayer : MonoBehaviour
{
    bool isRotate = true;
    public float rotateSpeed;
    public float drugRotateSpeed;
    Vector3 prevPosition;

    public Toggle toggle;

    public void Update()
    {
        if (isRotate)
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0), Space.World);
        }

        if (Input.GetMouseButtonDown(0))
        {
            prevPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 drugRotateAngle = -1 * drugRotateSpeed * (Input.mousePosition - prevPosition);
            transform.Rotate(new Vector3(0, drugRotateAngle.x, 0), Space.World);
            prevPosition = Input.mousePosition;
        }
    }

    public void ToggleRotate()
    {
        isRotate = toggle.isOn;
    }
}
