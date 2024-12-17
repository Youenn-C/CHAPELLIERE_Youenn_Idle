using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [Header("Player"), Space(5)]
    public int _defaultClic = 2;
    public int _strength = 1;

    [Header("Table References"), Space(5)]
    [SerializeField] private int _tablesCurrentLevel;
    [SerializeField] private TMP_Text _tablesCurrentLevelText;
    [SerializeField] private Button _tablesUpgradeButton;

    [Header("Barrels References"), Space(5)]
    [SerializeField] private int _barrelCurrentLevel;
    [SerializeField] private TMP_Text _barrelCurrentLevelText;
    [SerializeField] private Button _barrelUpgradeButton;
    
    void Start()
    {
        _tablesCurrentLevelText.text = "Lvl : " + _tablesCurrentLevel.ToString();
        _barrelCurrentLevelText.text = "Lvl : " + _barrelCurrentLevel.ToString();
    }

    public void UpgradeTables()
    {
        _tablesCurrentLevel ++;
    }

    public void UpgradeBarrels()
    {
        _barrelCurrentLevel ++;
    }

    public void UpgradeClicStrength()
    {
        _strength *= 2;
    }
}
