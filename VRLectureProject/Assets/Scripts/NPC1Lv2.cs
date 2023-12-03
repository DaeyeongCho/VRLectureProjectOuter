using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC1Lv2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshPro ������Ʈ
    private int interactionCount = 1; // ��ȣ�ۿ� Ƚ��

    public GameObject startOtherObject; // �ٸ� ������Ʈ
    public string startFunctionName; // ���� �� �Լ� �̸�

    private bool missionClear = false;
    public GameObject clearOtherObject; // �ٸ� ������Ʈ
    public string clearFunctionName; // ���� �� �Լ� �̸�

    public GameObject endOtherObject; // �ٸ� ������Ʈ
    public string endFunctionName; // ���� �� �Լ� �̸�

    public void Interact()
    {
        switch (interactionCount)
        {
            case 1:
                textComponent.text = "������!";
                interactionCount++;
                break;
            case 2:
                textComponent.text = "�������� ģ������ �������!";
                interactionCount++;
                break;
            case 3:
                textComponent.text = "�������� 5������ �ٱ��Ͽ� ��� ��!!";
                interactionCount++;
                break;
            case 4:
                StartMission();
                interactionCount++;
                break;
            case 5:
                if (missionClear) // �̼� �Ϸ� ���� Ȯ��
                {
                    textComponent.text = "�����߱���!";
                    interactionCount++; // �̼� �Ϸ� �� ���� ���·� �Ѿ
                }
                else
                {
                    textComponent.text = "���� �������� ģ������ ��� ã�� ���߾�!";
                    // ���⼭ interactionCount�� ������Ű�� ����
                }
                break;
            case 6:
                textComponent.text = "����!";
                interactionCount++;
                break;
            case 7:
                textComponent.text = "���п� ģ������ ã�Ҿ�!";
                interactionCount++;
                break;
            case 8:
                textComponent.text = "���� �ܰ�� ���� ���� �����ٰ�!";
                interactionCount++;
                OpenNextStage();
                break;
            case 9:
                // ���� ���� ����
                break;
        }
    }

    private void StartMission()
    {
        // �ٸ� ������Ʈ�� �Լ� ����
        if (startOtherObject != null && !string.IsNullOrEmpty(startFunctionName))
            startOtherObject.SendMessage(startFunctionName, SendMessageOptions.DontRequireReceiver);
    }

    private void OpenNextStage()
    {
        // �ٸ� ������Ʈ�� �Լ� ����
        if (endOtherObject != null && !string.IsNullOrEmpty(endFunctionName))
            endOtherObject.SendMessage(endFunctionName, SendMessageOptions.DontRequireReceiver);
    }

    public void setClear()
    {
        missionClear = true;
        // �ٸ� ������Ʈ�� �Լ� ����
        if (clearOtherObject != null && !string.IsNullOrEmpty(clearFunctionName))
            clearOtherObject.SendMessage(clearFunctionName, SendMessageOptions.DontRequireReceiver);
        Interact();
    }
}
