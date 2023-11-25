using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� TextMeshProUGUI ������Ʈ
    private int score = 0; // ���� ����

    void UpdateScoreDisplay()
    {
        scoreText.text = "����: " + score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }
}
