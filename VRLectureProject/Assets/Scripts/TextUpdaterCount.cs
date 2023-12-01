using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro ���ӽ����̽��� ����մϴ�.
using Oculus.Interaction;

public class TextUpdaterCount : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshProUGUI ������Ʈ�� ���� ����
    private int count = 0;

    public GameObject otherObject;
    public string functionName;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject otherObject2; // �ٸ� ������Ʈ
    public string functionName2; // ���� �� �Լ� �̸�

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

            // �ٸ� ������Ʈ�� �Լ� ����
            if (otherObject2 != null && !string.IsNullOrEmpty(functionName2))
                otherObject2.SendMessage(functionName2, SendMessageOptions.DontRequireReceiver);
        }
    }
}
