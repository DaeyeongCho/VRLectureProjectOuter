using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PrimaryButtonWatcher : MonoBehaviour
{
    public XRController controller;
    public LayerMask groundLayer;
    public Transform XROrigin;
    public float moveSpeed = 1.0f;
    public float maxRaycastDistance = 1.0f; // Max Raycast Distance Ãß°¡

    private bool isHandFixed = false;
    private Vector3 fixedPosition;
    private Quaternion fixedRotation;

    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue)
        {
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit, maxRaycastDistance, groundLayer))
            {
                if (!isHandFixed)
                {
                    fixedPosition = hit.point;
                    fixedRotation = controller.transform.rotation;
                    isHandFixed = true;
                }
            }
        }
        else
        {
            isHandFixed = false;
        }

        if (isHandFixed)
        {
            Vector3 direction = fixedRotation * Vector3.forward - controller.transform.rotation * Vector3.forward;
            XROrigin.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}