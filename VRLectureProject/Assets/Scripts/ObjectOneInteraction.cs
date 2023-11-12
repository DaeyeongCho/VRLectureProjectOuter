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
        // 레이캐스트를 사용하여 오브젝트를 조준합니다.
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit, Mathf.Infinity, interactableLayer))
        {
            currentTarget = hit.collider.gameObject;
        }
        else
        {
            currentTarget = null;
        }

        // A 버튼의 상태를 확인합니다.
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            // 버튼이 눌렸을 때만 상호작용합니다.
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
