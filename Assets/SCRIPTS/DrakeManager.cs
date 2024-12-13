using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrakeManager : MonoBehaviour
{
    [Header("Drake"), Space(5)]
    [SerializeField] private TMP_Text richnessText;

    private void Start()
    {
        UpdateDrakeUI();
    }

    public void AddDrake(int amount)
    {
        Inventory.Instance.richness += amount;
        UpdateDrakeUI();
    }

    public void UpdateDrakeUI()
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
