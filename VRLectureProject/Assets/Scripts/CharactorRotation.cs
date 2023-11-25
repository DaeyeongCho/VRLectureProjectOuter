using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharactorRotation : MonoBehaviour
{
    public Transform xrCamera;

    void Update()
    {
        // XR ī�޶��� ȸ������ y��(������) ȸ�� ���� �����ɴϴ�.
        float yRotation = xrCamera.eulerAngles.y;

        // ĳ������ ȸ���� XR ī�޶��� y�� ȸ�� ������ �����մϴ�.
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
