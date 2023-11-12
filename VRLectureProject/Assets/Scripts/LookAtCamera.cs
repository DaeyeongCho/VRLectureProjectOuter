using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        Vector3 directionToCamera = cameraTransform.position - transform.position;
        directionToCamera.y = 0; // Y�� ȸ������ ����մϴ�.
        Quaternion rotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = rotation;
    }
}
