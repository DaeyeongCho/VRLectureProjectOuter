using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public bool lookAway; // 카메라의 반대 방향을 바라보게 하는 옵션

    void Update()
    {
        Vector3 directionToCamera = cameraTransform.position - transform.position;
        directionToCamera.y = 0; // Y축 회전만을 고려합니다.

        if (lookAway)
        {
            directionToCamera = -directionToCamera; // 반대 방향을 바라보게 합니다.
        }

        Quaternion rotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = rotation;
    }
}
