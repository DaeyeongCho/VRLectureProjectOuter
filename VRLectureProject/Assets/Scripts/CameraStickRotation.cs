using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraStickRotation : MonoBehaviour
{
    public XRController controller;
    public Transform cameraRig; // XR Rig 또는 카메라의 부모 오브젝트
    public float rotationSpeed = 50.0f; // 회전 속도

    void Update()
    {
        // 컨트롤러의 스틱 입력을 받습니다.
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 stickInput))
        {
            // 스틱의 수평 입력을 기반으로 회전 각도를 계산합니다.
            float rotationAmount = stickInput.x * rotationSpeed * Time.deltaTime;

            // 카메라(또는 XR Rig)를 수평 방향으로 회전시킵니다.
            cameraRig.Rotate(0, rotationAmount, 0);
        }
    }
}
