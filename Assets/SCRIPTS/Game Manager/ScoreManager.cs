using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assurez-vous d'importer le namespace TMP

public class ScoreManager : MonoBehaviour
{
    [Header("Score"), Space(5)]
    public int score;
    [SerializeField] private TMP_Text _scoreText;

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
        if (_scoreText != null)
        {
            _scoreText.text = "Score : " + score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }
}