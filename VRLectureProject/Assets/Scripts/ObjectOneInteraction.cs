using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectOneInteraction : MonoBehaviour
{
    public XRController controller;
    public LayerMask interactableLayer;

    private bool isButtonPressed = false;
    private GameObject currentTarget = null;

    void Update()
    {
        // ����ĳ��Ʈ�� ����Ͽ� ������Ʈ�� �����մϴ�.
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit, Mathf.Infinity, interactableLayer))
        {
            currentTarget = hit.collider.gameObject;
        }
        else
        {
            currentTarget = null;
        }

        // A ��ư�� ���¸� Ȯ���մϴ�.
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            // ��ư�� ������ ���� ��ȣ�ۿ��մϴ�.
            if (isPressed && !isButtonPressed && currentTarget != null)
            {
                InteractWith(currentTarget);
                isButtonPressed = true;
            }
            else if (!isPressed && isButtonPressed)
            {
                isButtonPressed = false;
            }
        }
    }

    private void InteractWith(GameObject gameObject)
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }
}
