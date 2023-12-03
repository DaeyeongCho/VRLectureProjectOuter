using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindTimerCollaboration : MonoBehaviour
{
    // �ν����� â���� ���� ������ ��ҵ�
    public int findCount; // ã�ƾ� �� ����
    public TextMeshProUGUI countText; // ã�� ���� ī��Ʈ�� �ؽ�Ʈ
    public TextMeshProUGUI timerText; // Ÿ�̸� ǥ�ÿ� �ؽ�Ʈ
    public int timerDuration; // Ÿ�̸� �ð�(��)

    public GameObject findObject; // ã�� �� ������ ������Ʈ
    public string findFunctionName; // ã�� �� ������ �Լ���

    public GameObject findAllObject; // ��� ã���� �� ������ ������Ʈ
    public string findAllFunctionName; // ��� ã���� �� ������ �Լ���

    public GameObject startObject; // ���� �� ������ ������Ʈ
    public string startFunctionName; // ���� �� ������ �Լ���

    public GameObject endObject; // ���� �� ������ ������Ʈ
    public string endFunctionName; // ���� �� ������ �Լ���

    private int currentCount = 0;
    private Coroutine timerCoroutine;

    // Ÿ�̸� ����
    public void Start()
    {
        if (startObject != null && !string.IsNullOrEmpty(startFunctionName))
            startObject.SendMessage(startFunctionName);

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    // Ÿ�̸� ����
    public void Stop()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;

            if (timerText != null)
                timerText.text = "Ÿ�̸� �ߴܵ�";

            if (endObject != null && !string.IsNullOrEmpty(endFunctionName))
                endObject.SendMessage(endFunctionName);
        }
    }

    // ã�� �Լ�
    public void Find()
    {
        currentCount++;
        if (countText != null)
            countText.text = "ã�� ����: " + currentCount + "��";

        if (findObject != null && !string.IsNullOrEmpty(findFunctionName))
            findObject.SendMessage(findFunctionName);

        if (currentCount >= findCount)
        {
            if (findAllObject != null && !string.IsNullOrEmpty(findAllFunctionName))
                findAllObject.SendMessage(findAllFunctionName);

            Stop();
        }
    }

    // Ÿ�̸� �ڷ�ƾ
    private IEnumerator TimerCoroutine()
    {
        int remainingTime = timerDuration;
        while (remainingTime > 0)
        {
            if (timerText != null)
                timerText.text = "���� �ð�: " + remainingTime + "��";

            yield return new WaitForSeconds(1);
            remainingTime--;

            if (remainingTime <= 0)
                Stop();
        }
    }
}