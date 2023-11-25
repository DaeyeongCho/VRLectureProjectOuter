using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraStickRotation : MonoBehaviour
{
    public XRController controller;
    public Transform cameraRig; // XR Rig �Ǵ� ī�޶��� �θ� ������Ʈ
    public float rotationSpeed = 50.0f; // ȸ�� �ӵ�

    void Update()
    {
        // ��Ʈ�ѷ��� ��ƽ �Է��� �޽��ϴ�.
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 stickInput))
        {
            // ��ƽ�� ���� �Է��� ������� ȸ�� ������ ����մϴ�.
            float rotationAmount = stickInput.x * rotationSpeed * Time.deltaTime;

            // ī�޶�(�Ǵ� XR Rig)�� ���� �������� ȸ����ŵ�ϴ�.
            cameraRig.Rotate(0, rotationAmount, 0);
        }
    }
}
