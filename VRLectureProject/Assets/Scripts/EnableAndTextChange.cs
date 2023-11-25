using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableAndTextChange : MonoBehaviour
{
    public GameObject objectToActivate; // 활성화할 오브젝트
    public TextMeshProUGUI tmpTextComponent; // 변경할 TMP 텍스트 컴포넌트
    public string newText = "고마워! 다음 단계로 넘어가는 길을 열어두었어!"; // 새로 설정할 텍스트
    public AudioSource audioSource; // 오디오 소스 컴포넌트
    public AudioClip audioClip; // 재생할 오디오 클립
    public GameObject objectToDeactivate; // 비활성화할 오브젝트

    // 이 함수가 호출되면 지정된 작업을 수행합니다
    public void ActivateObjectAndChangeText()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // 오브젝트 활성화
        }

        if (tmpTextComponent != null)
        {
            tmpTextComponent.text = newText;
        }
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip; // 오디오 클립 설정
            audioSource.Play(); // 오디오 재생
        }
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false); // 오브젝트 비활성화
        }
    }
}
