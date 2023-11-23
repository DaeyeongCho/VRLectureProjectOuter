using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteract : MonoBehaviour
{
    public GameObject npcObject; // NPC ������Ʈ
    public float interactDistance = 3f; // ���� ������ �ִ� �Ÿ�

    private bool isAimingAtNPC = false;
    public GameObject targetObject;
    public GameObject objectToEnable;
    public GameObject objectToEnable1;

    void Update()
    {
        AimAtNPC();
        if (isAimingAtNPC && Input.GetButtonDown("Fire1")) // "Fire1"�� �⺻������ A ��ư�� ���ε˴ϴ�.
        {
            InteractWithNPC();
        }
    }

    void AimAtNPC()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            if (hit.collider.gameObject == npcObject)
            {
                isAimingAtNPC = true;
            }
            else
            {
                isAimingAtNPC = false;
            }
        }
        else
        {
            isAimingAtNPC = false;
        }
    }

    void InteractWithNPC()
    {

        UpdateTextMeshPro updateScript = targetObject.GetComponent<UpdateTextMeshPro>();

        // ��ũ��Ʈ�� �����ϸ�, ChangeText �Լ��� ȣ���մϴ�.
        if (updateScript != null)
        {
            updateScript.ChangeText("������ ã�� ��!");
            ActivateObject();


            // ���⿡ NPC�� ��ȣ�ۿ��ϴ� �ڵ带 �ۼ��մϴ�.
            // Debug.Log("Interacting with NPC");
        }
    }

    public void ActivateObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
        if (objectToEnable1 != null)
        {
            objectToEnable1.SetActive(true);
        }
    }
}
