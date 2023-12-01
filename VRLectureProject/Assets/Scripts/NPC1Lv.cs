using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshPro 컴포넌트
    public GameObject missionObject; // 미션 관련 오브젝트의 참조
    private int interactionCount = 1; // 상호작용 횟수

    public GameObject objectToActivate;
    public GameObject secondObjectToActivate;

    public GameObject thirdObjectToActivate;

    public GameObject fourthObjectToActivate;

    private bool missionClear = false;

    public AudioSource audioSource; // 오디오 소스 컴포넌트에 대한 참조
    public AudioClip audioClip; // 재생할 오디오 클립

    public GameObject otherObject; // 다른 오브젝트
    public string functionName; // 실행 할 함수 이름

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
                textComponent.text = "꼬마버섯 5마리를 찾아 줘!!";
                interactionCount++;
                break;
            case 4:
                StartMission();
                interactionCount++;
                break;
            case 5:
                if (CheckMissionCompleted()) // 미션 완료 여부 확인
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
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if (secondObjectToActivate != null)
        {
            secondObjectToActivate.SetActive(true);
        }

        // 다른 오브젝트의 함수 실행
        if (otherObject != null && !string.IsNullOrEmpty(functionName))
            otherObject.SendMessage(functionName, SendMessageOptions.DontRequireReceiver);
    }

    private bool CheckMissionCompleted()
    {
        // 미션 완료 여부를 확인하는 로직
        // 예: return missionObject.GetComponent<MissionScript>().IsMissionCompleted();
        return missionClear;
    }

    private void OpenNextStage()
    {
        // 다음 단계로 넘어가는 로직
        // 예: missionObject.GetComponent<MissionScript>().OpenNextStage();
        if (fourthObjectToActivate != null)
        {
            fourthObjectToActivate.SetActive(true);

            // AudioSource에 AudioClip 할당 및 재생
            if (audioSource != null && audioClip != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }

    public void setClear()
    {
        missionClear = true;

        if (thirdObjectToActivate != null)
        {
            thirdObjectToActivate.SetActive(false);
        }
    }
}
