using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPowerful : MonoBehaviour
{
    public GameObject targetObject; // 인스펙터에서 지정할 대상 오브젝트
    public float maxRayDistance = 1.5f;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject objectToActivate;
    public GameObject objectToNoneActivate;
    public GameObject otherObject;
    public string functionName;
    public GameObject effectPrefab;
    public float distroyEffectTime = 3f;
    public Vector3 effectScale = Vector3.one;
    public Vector3 effectOffset = Vector3.zero;
    private GameObject targetedObject;
    public bool destroyTargetObject;
    public GameObject leftController;
    public GameObject rightController;

    void Start()
    {
        // 대상 오브젝트에 캡슐 콜라이더 추가
        if (targetObject != null && targetObject.GetComponent<CapsuleCollider>() == null)
        {
            targetObject.AddComponent<CapsuleCollider>();
        }
    }

    void Update()
    {
        CheckRaycast(leftController);
        CheckRaycast(rightController);
    }

    void CheckRaycast(GameObject controller)
    {
        if (controller == null || targetObject == null) return;

        RaycastHit hit;
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, maxRayDistance))
        {
            if (hit.collider.gameObject == targetObject)
            {
                targetedObject = hit.collider.gameObject;
                HandleInput();
            }
        }
    }

    void HandleInput()
    {
        if (targetedObject != null && Input.GetButtonDown("Fire1"))
        {
            PerformAction(targetedObject.transform.position);
        }
    }

    void PerformAction(Vector3 hitPoint)
    {
        // 오디오 재생
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        // 오브젝트 활성화
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // 오브젝트 비활성화
        if (objectToNoneActivate != null)
        {
            objectToNoneActivate.SetActive(false);
        }

        // 다른 오브젝트의 함수 호출
        if (otherObject != null && !string.IsNullOrEmpty(functionName))
        {
            otherObject.SendMessage(functionName);
        }

        // 이펙트 생성
        if (effectPrefab != null)
        {
            GameObject effectInstance = Instantiate(effectPrefab, hitPoint + effectOffset, Quaternion.identity);
            effectInstance.transform.localScale = effectScale; // 이펙트 크기 조정
            Destroy(effectInstance, distroyEffectTime); // 3초 뒤에 이펙트 인스턴스를 파괴
        }


        // 조준하고 있는 오브젝트 파괴 여부 결정
        if (targetedObject != null && destroyTargetObject)
        {
            Destroy(targetedObject);
            targetedObject = null;
        }
    }
}
