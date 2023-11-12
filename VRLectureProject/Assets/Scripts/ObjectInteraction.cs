using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInteraction : MonoBehaviour
{
    public XRController controller; // VR 컨트롤러
    public LayerMask interactableLayer; // 상호작용할 수 있는 오브젝트의 레이어

    void Update()
    {
        // 레이캐스트를 사용하여 오브젝트를 조준합니다.
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit, Mathf.Infinity, interactableLayer))
        {
            // A 버튼이 눌렸는지 확인합니다.
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) && isPressed)
            {
                // 상호작용 로직을 실행합니다.
                InteractWith(hit.collider.gameObject);
            }
        }
    }

    private void InteractWith(GameObject gameObject)
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }
}
