using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float blinkSpeed;

    void Update()
    {
        BlinkTitleText();
    }

    void BlinkTitleText()
    {
        text.color = new Color(
            text.color.r,
            text.color.g,
            text.color.b,
            Mathf.PingPong(Time.time * blinkSpeed, 1f)
        );
    }
}
