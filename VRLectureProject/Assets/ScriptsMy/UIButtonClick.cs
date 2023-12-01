using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonClick : MonoBehaviour
{
    public string sceneNameToLoad; // 인스펙터 창에서 설정할 씬 이름
    public AudioSource audioSource; // 오디오 소스 컴포넌트
    public AudioClip audioClip; // 재생할 오디오 클립

    // 이 함수는 버튼이 클릭될 때 호출됩니다.
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        SceneManager.LoadScene(sceneNameToLoad);
        audioSource.clip = audioClip; // 오디오 클립 설정
        audioSource.Play(); // 오디오 재생
    }
}
