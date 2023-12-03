using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스를 사용합니다.
using Oculus.Interaction;

public class TextUpdaterCount : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshProUGUI 컴포넌트에 대한 참조
    private int count = 0;

    public GameObject otherObject;
    public string functionName;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject otherObject2; // 다른 오브젝트
    public string functionName2; // 실행 할 함수 이름

    // 텍스트를 업데이트하는 메서드
    public void setCount()
    {
        if (textComponent != null)
        {
            count++;
            textComponent.text = "찾은 개수: " + count;
        }

        if (count >= 5) {
            if (otherObject != null && !string.IsNullOrEmpty(functionName))
            {
                otherObject.SendMessage(functionName);
            }

            if (audioSource != null && audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }

            // 다른 오브젝트의 함수 실행
            if (otherObject2 != null && !string.IsNullOrEmpty(functionName2))
                otherObject2.SendMessage(functionName2, SendMessageOptions.DontRequireReceiver);
        }
    }
}
