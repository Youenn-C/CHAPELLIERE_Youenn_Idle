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
    public int _tablesCurrentLevel;
    [SerializeField] private int _tablesUpgradePrice;
    [SerializeField] private TMP_Text _tablesCurrentLevelText;
    [SerializeField] private TMP_Text _tablesUpgradePriceText;
    [SerializeField] private Button _tablesUpgradeButton;

    [Header("Barrels References"), Space(5)]
    [SerializeField] private int _barrelsMaxLevel = 5;
    public int _barrelCurrentLevel;
    [SerializeField] private int _barrelUpgradePrice;
    [SerializeField] private TMP_Text _barrelCurrentLevelText;
    [SerializeField] private TMP_Text _barrelsUpgradePriceText;
    [SerializeField] private Button _barrelsUpgradeButton;
    
    [Header("Strenght References"), Space(5)]
    [SerializeField] private int _strenghtMaxLevel = 10;
    [SerializeField] private int _strenghtCurrentLevel;
    [SerializeField] private int _strenghtUpgradePrice;
    [SerializeField] private TMP_Text _strenghtCurrentLevelText;
    [SerializeField] private TMP_Text _strenghtUpgradePriceText;
    [SerializeField] private Button _strenghtUpgradeButton;
    
    void Start()
    {
        _tablesCurrentLevelText.text = "Level : " + _tablesCurrentLevel.ToString();
        _barrelCurrentLevelText.text = "Level : " + _barrelCurrentLevel.ToString();
        _strenghtCurrentLevelText.text = "Level : " + _barrelCurrentLevel.ToString();
        
        _tablesUpgradePriceText.text = _tablesUpgradePrice.ToString();
        _barrelsUpgradePriceText.text = _barrelUpgradePrice.ToString();
        _strenghtUpgradePriceText.text = _strenghtUpgradePrice.ToString();
        
        if (Inventory.Instance.richness < _tablesUpgradePrice) _tablesUpgradeButton.interactable = false;
        if (Inventory.Instance.richness < _barrelUpgradePrice) _barrelsUpgradeButton.interactable = false;
        if (Inventory.Instance.richness < _strenghtUpgradePrice) _strenghtUpgradeButton.interactable = false;
    }

    void Update()
    {
        if (Inventory.Instance.richness >= _tablesUpgradePrice && _tablesCurrentLevel < _tablesMaxLevel) _tablesUpgradeButton.interactable = true;
        else
        {
            _tablesUpgradeButton.interactable = false;
        }
        if (Inventory.Instance.richness >= _barrelUpgradePrice && _barrelCurrentLevel < _barrelsMaxLevel) _barrelsUpgradeButton.interactable = true;
        else
        {
            _barrelsUpgradeButton.interactable = false;
        }
        if (Inventory.Instance.richness >= _strenghtUpgradePrice && _strenghtCurrentLevel < _strenghtMaxLevel) _strenghtUpgradeButton.interactable = true;
        else
        {
            _strenghtUpgradeButton.interactable = false;
        }
    }

    public void UpgradeTables()
    {
        if (_tablesCurrentLevel < _tablesMaxLevel)
        {
            if (Inventory.Instance.richness >= _tablesUpgradePrice)
            {
                Inventory.Instance.richness -= _tablesUpgradePrice;
                _tablesUpgradePrice *= 2;
                _tablesUpgradePriceText.text = _tablesUpgradePrice.ToString();
                GameManager.Instance.drakeManager.UpdateDrakeUI();
                
                _tablesCurrentLevel++;
                _tablesCurrentLevelText.text = "Level : " + _tablesCurrentLevel.ToString();
            }
            
            if (Inventory.Instance.richness < _tablesUpgradePrice)
            {
                _tablesUpgradeButton.interactable = false;
            }
        }
            
        if (_tablesCurrentLevel >= _tablesMaxLevel)
        {
            _tablesCurrentLevelText.text = "Level MAX";
            _tablesUpgradeButton.interactable = false;
        }
    }

    public void UpgradeBarrels()
    {
        if (_barrelCurrentLevel < _barrelsMaxLevel)
        {
            if (Inventory.Instance.richness >= _barrelUpgradePrice)
            {
                Inventory.Instance.richness -= _barrelUpgradePrice;
                _barrelUpgradePrice *= 2;
                _barrelsUpgradePriceText.text = _barrelUpgradePrice.ToString();
                GameManager.Instance.drakeManager.UpdateDrakeUI();
                
                _barrelCurrentLevel++;
                _barrelCurrentLevelText.text = "Level : " + _barrelCurrentLevel.ToString();
            }
            
            if (Inventory.Instance.richness < _barrelUpgradePrice)
            {
                _barrelsUpgradeButton.interactable = false;
            }
        }

        if (_barrelCurrentLevel >= _barrelsMaxLevel)
        {
            _barrelCurrentLevelText.text = "Level MAX";
            _barrelsUpgradeButton.interactable = false;
        }
    }

    public void UpgradeClicStrength()
    {
        if (_strenghtCurrentLevel < _strenghtMaxLevel)
        {
            if (Inventory.Instance.richness >= _strenghtUpgradePrice)
            {
                Inventory.Instance.richness -= _strenghtUpgradePrice;
                _strenghtUpgradePrice *= 2;
                _strenghtUpgradePriceText.text = _strenghtUpgradePrice.ToString();
                GameManager.Instance.drakeManager.UpdateDrakeUI();
                
                _strenghtCurrentLevel ++; 
                _strength = Mathf.Abs(_strength * 2);
                _strenghtCurrentLevelText.text = "Level : " + _strenghtCurrentLevel.ToString();
            }
            
            if (Inventory.Instance.richness < _strenghtUpgradePrice)
            {
                _strenghtUpgradeButton.interactable = false;
            }
        }
        
        if (_strenghtCurrentLevel >= _strenghtMaxLevel)
        {
            _strenghtCurrentLevelText.text = "Level MAX";
            _strenghtUpgradeButton.interactable = false;
        }
    }
}
