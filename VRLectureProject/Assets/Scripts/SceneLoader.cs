using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneNameToLoad; // 인스펙터 창에서 설정할 씬 이름

    // 이 함수는 설정된 씬을 로드합니다.
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
