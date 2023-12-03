using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC1Lv2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshPro 컴포넌트
    private int interactionCount = 1; // 상호작용 횟수

    public GameObject startOtherObject; // 다른 오브젝트
    public string startFunctionName; // 실행 할 함수 이름

    private bool missionClear = false;
    public GameObject clearOtherObject; // 다른 오브젝트
    public string clearFunctionName; // 실행 할 함수 이름

    public GameObject endOtherObject; // 다른 오브젝트
    public string endFunctionName; // 실행 할 함수 이름

    public void Interact()
    {
        switch (interactionCount)
        {
            case 1:
                textComponent.text = "도와줘!";
                interactionCount++;
                break;
            case 2:
                textComponent.text = "꼬마버섯 친구들이 사라졌어!";
                interactionCount++;
                break;
            case 3:
                textComponent.text = "꼬마버섯 5마리를 바구니에 담아 줘!!";
                interactionCount++;
                break;
            case 4:
                StartMission();
                interactionCount++;
                break;
            case 5:
                if (missionClear) // 미션 완료 여부 확인
                {
                    textComponent.text = "성공했구나!";
                    interactionCount++; // 미션 완료 시 다음 상태로 넘어감
                }
                else
                {
                    textComponent.text = "아직 꼬마버섯 친구들을 모두 찾지 못했어!";
                    // 여기서 interactionCount를 증가시키지 않음
                }
                break;
            case 6:
                textComponent.text = "고마워!";
                interactionCount++;
                break;
            case 7:
                textComponent.text = "덕분에 친구들을 찾았어!";
                interactionCount++;
                break;
            case 8:
                textComponent.text = "다음 단계로 가는 길을 열어줄게!";
                interactionCount++;
                OpenNextStage();
                break;
            case 9:
                // 이후 반응 없음
                break;
        }
    }

    private void StartMission()
    {
        // 다른 오브젝트의 함수 실행
        if (startOtherObject != null && !string.IsNullOrEmpty(startFunctionName))
            startOtherObject.SendMessage(startFunctionName, SendMessageOptions.DontRequireReceiver);
    }

    private void OpenNextStage()
    {
        // 다른 오브젝트의 함수 실행
        if (endOtherObject != null && !string.IsNullOrEmpty(endFunctionName))
            endOtherObject.SendMessage(endFunctionName, SendMessageOptions.DontRequireReceiver);
    }

    public void setClear()
    {
        missionClear = true;
        // 다른 오브젝트의 함수 실행
        if (clearOtherObject != null && !string.IsNullOrEmpty(clearFunctionName))
            clearOtherObject.SendMessage(clearFunctionName, SendMessageOptions.DontRequireReceiver);
        Interact();
    }
}
