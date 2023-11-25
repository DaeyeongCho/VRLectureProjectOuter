using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRObjectInteractor : MonoBehaviour
{
    public LayerMask itemLayer; // "item" 레이어를 가리키는 레이어 마스크
    public float maxRayDistance = 5f; // Raycast의 최대 거리
    public GameObject otherObject; // 다른 오브젝트의 참조

    private GameObject targetedObject; // 현재 조준하고 있는 오브젝트

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance, itemLayer))
        {
            // "item" 레이어의 오브젝트를 조준하고 있을 때
            targetedObject = hit.collider.gameObject;
        }
        else
        {
            targetedObject = null;
        }

        if (targetedObject != null && Input.GetButtonDown("Fire1")) // "Fire1"은 일반적으로 A 버튼에 매핑됩니다.
        {
            // 조준한 오브젝트를 비활성화하고 특정 함수 실행
            targetedObject.SetActive(false);
            PerformAction();
        }
    }

    void PerformAction()
    {
        // 조준하고 있는 오브젝트 제거
        if (targetedObject != null)
        {
            Destroy(targetedObject);
            targetedObject = null;
        }

        // 다른 오브젝트의 스크립트 함수 호출
        if (otherObject != null)
        {
            ScoreManager script = otherObject.GetComponent<ScoreManager>();
            if (script != null)
            {
                script.AddScore(1);
            }
        }
    }
}
