using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 TextMeshProUGUI 컴포넌트
    private int score = 0; // 현재 점수
    public AudioSource audioSource; // 오디오 소스 컴포넌트
    public AudioClip audioClip; // 재생할 오디오 클립

    void UpdateScoreDisplay()
    {
        scoreText.text = "찾은 수: " + score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip; // 오디오 클립 설정
            audioSource.Play(); // 오디오 재생
        }
    }

    public int GetScore()
    {
        return score;
    }
}
