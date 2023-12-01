using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스 사용

public class TextChanger : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshPro 컴포넌트
    private int textIndex = 0; // 현재 표시할 문자열의 인덱스
    private string[] texts = new string[] // 표시할 문자열 배열
    {
        "첫 번째 메시지",
        "두 번째 메시지",
        "세 번째 메시지",
        // ... 추가 메시지
    };

    // 이 함수는 특정 이벤트가 발생할 때 호출됩니다.
    public void ChangeText()
    {
        if(textComponent != null && texts.Length > 0)
        {
            textComponent.text = texts[textIndex]; // 현재 인덱스의 텍스트를 설정
            textIndex = (textIndex + 1) % texts.Length; // 다음 텍스트로 인덱스 업데이트
        }
    }

    // 이 함수는 다른 특정 이벤트가 발생할 때 호출될 수 있습니다.
    public void ResetText()
    {
        if(textComponent != null)
        {
            textComponent.text = "초기 메시지"; // 초기 메시지로 설정
        }
    }

    // 다른 함수들...
}
