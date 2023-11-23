using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 TextMeshProUGUI 컴포넌트
    private int score = 0; // 현재 점수

    void UpdateScoreDisplay()
    {
        scoreText.text = "점수: " + score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }
}
