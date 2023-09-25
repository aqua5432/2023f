using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Image aimImage;

    Vector3 targetPos;

    void Update()
    {
        transform.position = Input.mousePosition;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            targetPos = hit.point;

            if (hit.transform.CompareTag("Enemy"))
            {
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                aimImage.color = new Color(0f, 1.0f, 1.0f, 1.0f);
            }
        }else
        {
            // 照準器の色を「水色」（色は自由に変更してください。）
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
