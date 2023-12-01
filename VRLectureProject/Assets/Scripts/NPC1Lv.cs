using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshPro ������Ʈ
    public GameObject missionObject; // �̼� ���� ������Ʈ�� ����
    private int interactionCount = 1; // ��ȣ�ۿ� Ƚ��

    public GameObject objectToActivate;
    public GameObject secondObjectToActivate;

    public GameObject thirdObjectToActivate;

    public GameObject fourthObjectToActivate;

    private bool missionClear = false;

    public AudioSource audioSource; // ����� �ҽ� ������Ʈ�� ���� ����
    public AudioClip audioClip; // ����� ����� Ŭ��

    public void Interact()
    {
        switch (interactionCount)
        {
            case 1:
                textComponent.text = "������!";
                interactionCount++;
                break;
            case 2:
                textComponent.text = "���� npc��.";
                interactionCount++;
                break;
            case 3:
                textComponent.text = "�̼��� Ŭ������ ��!";
                interactionCount++;
                break;
            case 4:
                StartMission();
                interactionCount++;
                break;
            case 5:
                if (CheckMissionCompleted()) // �̼� �Ϸ� ���� Ȯ��
                {
                    textComponent.text = "����!";
                    interactionCount++; // �̼� �Ϸ� �� ���� ���·� �Ѿ
                }
                else
                {
                    textComponent.text = "�̼��� ���� �Ϸ����� ���߾�!";
                    // ���⼭ interactionCount�� ������Ű�� ����
                }
                break;
            case 6:
                textComponent.text = "����!";
                interactionCount++;
                break;
            case 7:
                textComponent.text = "���п� ���� �� �ذ�ƾ�.";
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
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if (secondObjectToActivate != null)
        {
            secondObjectToActivate.SetActive(true);
        }
    }

    private bool CheckMissionCompleted()
    {
        // �̼� �Ϸ� ���θ� Ȯ���ϴ� ����
        // ��: return missionObject.GetComponent<MissionScript>().IsMissionCompleted();
        return missionClear;
    }

    private void OpenNextStage()
    {
        // ���� �ܰ�� �Ѿ�� ����
        // ��: missionObject.GetComponent<MissionScript>().OpenNextStage();
        if (fourthObjectToActivate != null)
        {
            fourthObjectToActivate.SetActive(true);

            // AudioSource�� AudioClip �Ҵ� �� ���
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
