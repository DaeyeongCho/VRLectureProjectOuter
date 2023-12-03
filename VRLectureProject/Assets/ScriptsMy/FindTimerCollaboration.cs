using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindTimerCollaboration : MonoBehaviour
{
    // 인스펙터 창에서 설정 가능한 요소들
    public int findCount; // 찾아야 할 개수
    public TextMeshProUGUI countText; // 찾은 개수 카운트용 텍스트
    public TextMeshProUGUI timerText; // 타이머 표시용 텍스트
    public int timerDuration; // 타이머 시간(초)

    public GameObject findObject; // 찾을 때 실행할 오브젝트
    public string findFunctionName; // 찾을 때 실행할 함수명

    public GameObject findAllObject; // 모두 찾았을 때 실행할 오브젝트
    public string findAllFunctionName; // 모두 찾았을 때 실행할 함수명

    public GameObject startObject; // 시작 시 실행할 오브젝트
    public string startFunctionName; // 시작 시 실행할 함수명

    public GameObject endObject; // 종료 시 실행할 오브젝트
    public string endFunctionName; // 종료 시 실행할 함수명

    private int currentCount = 0;
    private Coroutine timerCoroutine;

    // 타이머 시작
    public void Start()
    {
        if (startObject != null && !string.IsNullOrEmpty(startFunctionName))
            startObject.SendMessage(startFunctionName);

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    // 타이머 중지
    public void Stop()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;

            if (timerText != null)
                timerText.text = "타이머 중단됨";

            if (endObject != null && !string.IsNullOrEmpty(endFunctionName))
                endObject.SendMessage(endFunctionName);
        }
    }

    // 찾기 함수
    public void Find()
    {
        currentCount++;
        if (countText != null)
            countText.text = "찾은 개수: " + currentCount + "개";

        if (findObject != null && !string.IsNullOrEmpty(findFunctionName))
            findObject.SendMessage(findFunctionName);

        if (currentCount >= findCount)
        {
            if (findAllObject != null && !string.IsNullOrEmpty(findAllFunctionName))
                findAllObject.SendMessage(findAllFunctionName);

            Stop();
        }
    }

    // 타이머 코루틴
    private IEnumerator TimerCoroutine()
    {
        int remainingTime = timerDuration;
        while (remainingTime > 0)
        {
            if (timerText != null)
                timerText.text = "남은 시간: " + remainingTime + "초";

            yield return new WaitForSeconds(1);
            remainingTime--;

            if (remainingTime <= 0)
                Stop();
        }
    }
}