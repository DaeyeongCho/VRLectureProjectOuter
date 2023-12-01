using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위한 네임스페이스

public class CombinedTimerScript : MonoBehaviour
{
    public float timerDuration; // 시간 지정 (초 단위)
    public TextMeshProUGUI timerText; // 텍스트(TMP) 오브젝트

    public GameObject startObject; // 시작 시 실행할 다른 오브젝트
    public string startFunctionName; // 시작 시 실행할 다른 오브젝트의 함수명

    public GameObject everySecondObject; // 매 초 실행할 다른 오브젝트
    public string everySecondFunctionName; // 매 초 실행할 다른 오브젝트의 함수명

    public GameObject endObject; // 종료 시 실행할 다른 오브젝트
    public string endFunctionName; // 종료 시 실행할 다른 오브젝트의 함수명

    private Coroutine timerCoroutine; // 타이머 코루틴을 참조하기 위한 변수

    public void StartTimer()
    {
        // 기존에 실행 중인 타이머가 있다면 중단
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null; // 코루틴 참조 초기화

            if (timerText != null)
                timerText.text = "타이머 중단됨";
        }
    }

    private IEnumerator TimerCoroutine()
    {
        if (startObject != null && !string.IsNullOrEmpty(startFunctionName))
            startObject.SendMessage(startFunctionName, SendMessageOptions.DontRequireReceiver);

        int remainingTime = (int)timerDuration;
        while (remainingTime > 0)
        {
            if (timerText != null)
                timerText.text = "남은 시간: " + remainingTime + "초";

            if (everySecondObject != null && !string.IsNullOrEmpty(everySecondFunctionName))
                everySecondObject.SendMessage(everySecondFunctionName, remainingTime, SendMessageOptions.DontRequireReceiver);

            yield return new WaitForSeconds(1);
            remainingTime--;
        }

        if (remainingTime <= 0 && endObject != null && !string.IsNullOrEmpty(endFunctionName))
            endObject.SendMessage(endFunctionName, SendMessageOptions.DontRequireReceiver);

        timerCoroutine = null; // 코루틴 참조 초기화
    }
}
