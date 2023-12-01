using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPowerful : MonoBehaviour
{
    public GameObject targetObject; // �ν����Ϳ��� ������ ��� ������Ʈ
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
        // ��� ������Ʈ�� ĸ�� �ݶ��̴� �߰�
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
        // ����� ���
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        // ������Ʈ Ȱ��ȭ
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // ������Ʈ ��Ȱ��ȭ
        if (objectToNoneActivate != null)
        {
            objectToNoneActivate.SetActive(false);
        }

        // �ٸ� ������Ʈ�� �Լ� ȣ��
        if (otherObject != null && !string.IsNullOrEmpty(functionName))
        {
            otherObject.SendMessage(functionName);
        }

        // ����Ʈ ����
        if (effectPrefab != null)
        {
            GameObject effectInstance = Instantiate(effectPrefab, hitPoint + effectOffset, Quaternion.identity);
            effectInstance.transform.localScale = effectScale; // ����Ʈ ũ�� ����
            Destroy(effectInstance, distroyEffectTime); // 3�� �ڿ� ����Ʈ �ν��Ͻ��� �ı�
        }


        // �����ϰ� �ִ� ������Ʈ �ı� ���� ����
        if (targetedObject != null && destroyTargetObject)
        {
            Destroy(targetedObject);
            targetedObject = null;
        }
    }
}
