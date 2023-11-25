using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonClick : MonoBehaviour
{
    public string sceneNameToLoad; // �ν����� â���� ������ �� �̸�
    public AudioSource audioSource; // ����� �ҽ� ������Ʈ
    public AudioClip audioClip; // ����� ����� Ŭ��

    // �� �Լ��� ��ư�� Ŭ���� �� ȣ��˴ϴ�.
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        SceneManager.LoadScene(sceneNameToLoad);
        audioSource.clip = audioClip; // ����� Ŭ�� ����
        audioSource.Play(); // ����� ���
    }
}
