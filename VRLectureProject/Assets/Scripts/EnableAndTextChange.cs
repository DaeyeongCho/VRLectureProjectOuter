using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableAndTextChange : MonoBehaviour
{
    public GameObject objectToActivate; // Ȱ��ȭ�� ������Ʈ
    public TextMeshProUGUI tmpTextComponent; // ������ TMP �ؽ�Ʈ ������Ʈ
    public string newText = "����! ���� �ܰ�� �Ѿ�� ���� ����ξ���!"; // ���� ������ �ؽ�Ʈ
    public AudioSource audioSource; // ����� �ҽ� ������Ʈ
    public AudioClip audioClip; // ����� ����� Ŭ��
    public GameObject objectToDeactivate; // ��Ȱ��ȭ�� ������Ʈ

    // �� �Լ��� ȣ��Ǹ� ������ �۾��� �����մϴ�
    public void ActivateObjectAndChangeText()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // ������Ʈ Ȱ��ȭ
        }

        if (tmpTextComponent != null)
        {
            tmpTextComponent.text = newText;
        }
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip; // ����� Ŭ�� ����
            audioSource.Play(); // ����� ���
        }
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        }
    }
}
