using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneNameToLoad; // �ν����� â���� ������ �� �̸�

    // �� �Լ��� ������ ���� �ε��մϴ�.
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
