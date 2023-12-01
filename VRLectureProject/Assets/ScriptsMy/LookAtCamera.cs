using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public bool lookAway; // ī�޶��� �ݴ� ������ �ٶ󺸰� �ϴ� �ɼ�

    void Update()
    {
        Vector3 directionToCamera = cameraTransform.position - transform.position;
        directionToCamera.y = 0; // Y�� ȸ������ ����մϴ�.

        if (lookAway)
        {
            directionToCamera = -directionToCamera; // �ݴ� ������ �ٶ󺸰� �մϴ�.
        }

        Quaternion rotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = rotation;
    }
}
