using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [Header("Player"), Space(5)]
    public int _defaultClic = 2;
    public int _strength = 1;

    [Header("Table References"), Space(5)]
    [SerializeField] private int _tablesMaxLevel = 4;
    [SerializeField] private int _tablesCurrentLevel;
    [SerializeField] private TMP_Text _tablesCurrentLevelText;
    [SerializeField] private Button _tablesUpgradeButton;

    [Header("Barrels References"), Space(5)]
    [SerializeField] private int _barrelsMaxLevel = 5;
    [SerializeField] private int _barrelCurrentLevel;
    [SerializeField] private TMP_Text _barrelCurrentLevelText;
    [SerializeField] private Button _barrelsUpgradeButton;
    
    [Header("Strenght References"), Space(5)]
    [SerializeField] private int _strenghtMaxLevel = 10;
    [SerializeField] private int _strenghtCurrentLevel;
    [SerializeField] private TMP_Text _strenghtCurrentLevelText;
    [SerializeField] private Button _strenghtUpgradeButton;
    
    void Start()
    {
        _tablesCurrentLevelText.text = "Lvl : " + _tablesCurrentLevel.ToString();
        _barrelCurrentLevelText.text = "Lvl : " + _barrelCurrentLevel.ToString();
        _strenghtCurrentLevelText.text = "Lvl : " + _barrelCurrentLevel.ToString();
    }

    public void UpgradeTables()
    {
        if (_tablesCurrentLevel < _tablesMaxLevel)
        {
            _tablesCurrentLevel ++;
            
            _tablesCurrentLevelText.text = "Lvl : " + _tablesCurrentLevel.ToString();

            if (_tablesCurrentLevel >= _tablesMaxLevel)
            {
                _tablesUpgradeButton.interactable = false;
            }
        }
    }

    public void UpgradeBarrels()
    {
        if (_barrelCurrentLevel < _barrelsMaxLevel)
        {
            _barrelCurrentLevel ++;
            
            _barrelCurrentLevelText.text = "Lvl : " + _barrelCurrentLevel.ToString();

            if (_barrelCurrentLevel >= _barrelsMaxLevel)
            {
                _barrelsUpgradeButton.interactable = false;
            }
        }
    }

    public void UpgradeClicStrength()
    {
        if (_strenghtCurrentLevel < _strenghtMaxLevel)
        {
            _strenghtCurrentLevel ++; 
            _strength = Mathf.Abs(_strength * 2);
            
            _strenghtCurrentLevelText.text = "Lvl : " + _strenghtCurrentLevel.ToString();

            if (_strenghtCurrentLevel >= _strenghtMaxLevel)
            {
                _strenghtUpgradeButton.interactable = false;
            }
        }
    }
}
