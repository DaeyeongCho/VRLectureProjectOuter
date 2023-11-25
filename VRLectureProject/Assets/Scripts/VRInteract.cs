using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteract : MonoBehaviour
{
    public GameObject npcObject; // NPC 오브젝트
    public float interactDistance = 3f; // 조준 가능한 최대 거리

    private bool isAimingAtNPC = false;
    public GameObject targetObject;
    public GameObject objectToEnable;
    public GameObject objectToEnable1;
    public AudioSource audioSource; // 오디오 소스 컴포넌트
    public AudioClip audioClip; // 재생할 오디오 클립

    void Update()
    {
        AimAtNPC();
        if (isAimingAtNPC && Input.GetButtonDown("Fire1")) // "Fire1"은 기본적으로 A 버튼에 매핑됩니다.
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

        // 스크립트가 존재하면, ChangeText 함수를 호출합니다.
        if (updateScript != null)
        {
            updateScript.ChangeText("애기 버섯을 5개 찾아 줘!");
            ActivateObject();
            if (audioSource != null && audioClip != null)
            {
                audioSource.clip = audioClip; // 오디오 클립 설정
                audioSource.Play(); // 오디오 재생
            }

            // 여기에 NPC와 상호작용하는 코드를 작성합니다.
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
