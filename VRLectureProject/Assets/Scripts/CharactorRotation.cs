using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharactorRotation : MonoBehaviour
{
    public Transform xrCamera;

    void Update()
    {
        // XR 카메라의 회전에서 y축(수평축) 회전 값을 가져옵니다.
        float yRotation = xrCamera.eulerAngles.y;

        // 캐릭터의 회전을 XR 카메라의 y축 회전 값으로 설정합니다.
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
