using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrakeManager : MonoBehaviour
{
    public static DrakeManager Instance { get; private set; }

    [Header("Drake"), Space(5)]
    [SerializeField] private TMP_Text richnessText;

    

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
        UpdateDrakeUI();
    }

    public void AddDrake(int amount)
    {
        Inventory.Instance.richness += amount;
        UpdateDrakeUI();
    }

    private void UpdateDrakeUI()
    {
        if (richnessText != null)
        {
            richnessText.text = "Drakes : " + Inventory.Instance.richness.ToString();
        }
    }

    public int GetScore()
    {
        return Inventory.Instance.richness;
    }
}
