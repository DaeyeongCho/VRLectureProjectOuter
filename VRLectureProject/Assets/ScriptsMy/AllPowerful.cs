using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomActionScript : MonoBehaviour
{
    // 인스펙터에서 설정 가능한 요소들
    public GameObject targetObject; // 타겟 오브젝트

    public AudioSource audioSource; // 오디오 소스
    public AudioClip audioClip; // 오디오 클립

    public GameObject objectToActivate; // 활성화 할 오브젝트
    public GameObject objectToDeactivate; // 비활성화 할 오브젝트

    public GameObject otherObject; // 다른 오브젝트
    public string functionName; // 실행 할 함수 이름

    public GameObject effectPrefab; // 이펙트 프리팹
    public float effectDuration; // 이펙트 생성 후 제거 시간
    public Vector3 effectPosition; // 이펙트 발생 위치
    public float effectSize; // 이펙트 크기

    public bool shouldDestroyTarget; // 오브젝트 삭제 유무

    // PerformAction 함수 실행 시 수행될 동작
    public void PerformAction()
    {
        // 오디오 재생
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        // 오브젝트 활성화/비활성화
        if (objectToActivate != null)
            objectToActivate.SetActive(true);

        if (objectToDeactivate != null)
            objectToDeactivate.SetActive(false);

        // 다른 오브젝트의 함수 실행
        if (otherObject != null && !string.IsNullOrEmpty(functionName))
            otherObject.SendMessage(functionName, SendMessageOptions.DontRequireReceiver);

        // 이펙트 생성 및 제거
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(effectPrefab, effectPosition, Quaternion.identity);
            effect.transform.localScale = new Vector3(effectSize, effectSize, effectSize);
            Destroy(effect, effectDuration);
        }

        // 타겟 오브젝트 제거
        if (shouldDestroyTarget && targetObject != null)
            Destroy(targetObject);
    }
}
