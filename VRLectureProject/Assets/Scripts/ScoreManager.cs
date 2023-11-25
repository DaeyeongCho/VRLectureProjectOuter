using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� TextMeshProUGUI ������Ʈ
    private int score = 0; // ���� ����
    public AudioSource audioSource; // ����� �ҽ� ������Ʈ
    public AudioClip audioClip; // ����� ����� Ŭ��

    void UpdateScoreDisplay()
    {
        scoreText.text = "ã�� ��: " + score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip; // ����� Ŭ�� ����
            audioSource.Play(); // ����� ���
        }
    }

    public int GetScore()
    {
        return score;
    }
}
