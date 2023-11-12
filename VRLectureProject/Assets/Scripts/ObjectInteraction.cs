using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInteraction : MonoBehaviour
{
    public XRController controller; // VR ��Ʈ�ѷ�
    public LayerMask interactableLayer; // ��ȣ�ۿ��� �� �ִ� ������Ʈ�� ���̾�

    void Update()
    {
        // ����ĳ��Ʈ�� ����Ͽ� ������Ʈ�� �����մϴ�.
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit, Mathf.Infinity, interactableLayer))
        {
            // A ��ư�� ���ȴ��� Ȯ���մϴ�.
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) && isPressed)
            {
                // ��ȣ�ۿ� ������ �����մϴ�.
                InteractWith(hit.collider.gameObject);
            }
        }
    }

    private void InteractWith(GameObject gameObject)
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }
}
