using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    public XRController controller;
    public InputHelpers.Button clickButton = InputHelpers.Button.Trigger;
    public float activationThreshold = 0.1f;

    void Update()
    {
        if (controller.inputDevice.IsPressed(clickButton, out bool isPressed, activationThreshold))
        {
            if (isPressed)
            {
                // 여기에 버튼이 눌렸을 때 실행할 로직을 추가합니다.
            }
        }
    }
}
