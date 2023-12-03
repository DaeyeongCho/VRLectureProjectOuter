using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� ���ӽ����̽�

public class CombinedTimerScript : MonoBehaviour
{
    public float timerDuration; // �ð� ���� (�� ����)
    public TextMeshProUGUI timerText; // �ؽ�Ʈ(TMP) ������Ʈ

    public GameObject startObject; // ���� �� ������ �ٸ� ������Ʈ
    public string startFunctionName; // ���� �� ������ �ٸ� ������Ʈ�� �Լ���

    public GameObject everySecondObject; // �� �� ������ �ٸ� ������Ʈ
    public string everySecondFunctionName; // �� �� ������ �ٸ� ������Ʈ�� �Լ���

    public GameObject endObject; // ���� �� ������ �ٸ� ������Ʈ
    public string endFunctionName; // ���� �� ������ �ٸ� ������Ʈ�� �Լ���

    private Coroutine timerCoroutine; // Ÿ�̸� �ڷ�ƾ�� �����ϱ� ���� ����

    public void StartTimer()
    {
        // ������ ���� ���� Ÿ�̸Ӱ� �ִٸ� �ߴ�
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null; // �ڷ�ƾ ���� �ʱ�ȭ

            if (timerText != null)
                timerText.text = "Ÿ�̸� �ߴܵ�";
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
                timerText.text = "���� �ð�: " + remainingTime + "��";

            if (everySecondObject != null && !string.IsNullOrEmpty(everySecondFunctionName))
                everySecondObject.SendMessage(everySecondFunctionName, remainingTime, SendMessageOptions.DontRequireReceiver);

            yield return new WaitForSeconds(1);
            remainingTime--;
        }

        if (remainingTime <= 0 && endObject != null && !string.IsNullOrEmpty(endFunctionName))
            endObject.SendMessage(endFunctionName, SendMessageOptions.DontRequireReceiver);

        timerCoroutine = null; // �ڷ�ƾ ���� �ʱ�ȭ
    }
}
