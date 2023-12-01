using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro ���ӽ����̽��� ����մϴ�.

public class TextUpdaterCount : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshProUGUI ������Ʈ�� ���� ����
    private int count = 0;

    public GameObject otherObject;
    public string functionName;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // �ؽ�Ʈ�� ������Ʈ�ϴ� �޼���
    public void setCount()
    {
        if (textComponent != null)
        {
            count++;
            textComponent.text = "ã�� ����: " + count;
        }

        if (count >= 5) {
            if (otherObject != null && !string.IsNullOrEmpty(functionName))
            {
                otherObject.SendMessage(functionName);
            }

            if (audioSource != null && audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
