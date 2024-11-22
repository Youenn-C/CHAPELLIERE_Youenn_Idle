using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assurez-vous d'importer le namespace TMP

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Score"), Space(5)]
    [SerializeField] private int score = 0;
    [SerializeField] private TMP_Text scoreText; // Utilisez TMP_Text au lieu de Text
    
    private void Awake()
    {
        // Singleton pour assurer qu'il n'y a qu'une seule instance de ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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