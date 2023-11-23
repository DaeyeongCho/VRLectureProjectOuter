using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRObjectInteractor : MonoBehaviour
{
    public LayerMask itemLayer; // "item" ���̾ ����Ű�� ���̾� ����ũ
    public float maxRayDistance = 5f; // Raycast�� �ִ� �Ÿ�
    public GameObject otherObject; // �ٸ� ������Ʈ�� ����

    private GameObject targetedObject; // ���� �����ϰ� �ִ� ������Ʈ

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance, itemLayer))
        {
            // "item" ���̾��� ������Ʈ�� �����ϰ� ���� ��
            targetedObject = hit.collider.gameObject;
        }
        else
        {
            targetedObject = null;
        }

        if (targetedObject != null && Input.GetButtonDown("Fire1")) // "Fire1"�� �Ϲ������� A ��ư�� ���ε˴ϴ�.
        {
            // ������ ������Ʈ�� ��Ȱ��ȭ�ϰ� Ư�� �Լ� ����
            targetedObject.SetActive(false);
            PerformAction();
        }
    }

    void PerformAction()
    {
        // �����ϰ� �ִ� ������Ʈ ����
        if (targetedObject != null)
        {
            Destroy(targetedObject);
            targetedObject = null;
        }

        // �ٸ� ������Ʈ�� ��ũ��Ʈ �Լ� ȣ��
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
