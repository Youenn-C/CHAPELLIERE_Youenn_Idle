using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assurez-vous d'importer le namespace TMP

public class ScoreManager : MonoBehaviour
{
    [Header("Score"), Space(5)]
    [SerializeField] private int score;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }
}