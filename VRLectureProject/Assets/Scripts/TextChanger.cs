using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro ���ӽ����̽� ���

public class TextChanger : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // TextMeshPro ������Ʈ
    private int textIndex = 0; // ���� ǥ���� ���ڿ��� �ε���
    private string[] texts = new string[] // ǥ���� ���ڿ� �迭
    {
        "ù ��° �޽���",
        "�� ��° �޽���",
        "�� ��° �޽���",
        // ... �߰� �޽���
    };

    // �� �Լ��� Ư�� �̺�Ʈ�� �߻��� �� ȣ��˴ϴ�.
    public void ChangeText()
    {
        if(textComponent != null && texts.Length > 0)
        {
            textComponent.text = texts[textIndex]; // ���� �ε����� �ؽ�Ʈ�� ����
            textIndex = (textIndex + 1) % texts.Length; // ���� �ؽ�Ʈ�� �ε��� ������Ʈ
        }
    }

    // �� �Լ��� �ٸ� Ư�� �̺�Ʈ�� �߻��� �� ȣ��� �� �ֽ��ϴ�.
    public void ResetText()
    {
        if(textComponent != null)
        {
            textComponent.text = "�ʱ� �޽���"; // �ʱ� �޽����� ����
        }
    }

    // �ٸ� �Լ���...
}
