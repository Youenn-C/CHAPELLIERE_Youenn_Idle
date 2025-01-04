using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Tavernier : MonoBehaviour
{
    [Header("Reference"), Space(5)]
    [SerializeField] private GameObject _empoyTextButton;
    [SerializeField] private GameObject _levelUpButton;
    [SerializeField] private Button _tavernierButton;
    [SerializeField] private int tavernierLevel;
    [SerializeField] private int tavernierMaxLevel = 20;
    [SerializeField] private int multiplyingFactor = 1;
    [SerializeField] private int _tavernierUpgradePrice;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _tavernierUpgradePriceText;
    
    [Header("FeedBack Data"), Space(5)]
    [SerializeField] private Button _feedBackButton;
    [SerializeField] private int rewardAmount;
    private Vector2 startPosition;
    [SerializeField] private Vector2 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = _feedBackButton.transform.position;
        
        _empoyTextButton.SetActive(true);
        _levelUpButton.SetActive(false);
        tavernierLevel = 0;
        _levelText.text = "Inactif";
        
        _tavernierUpgradePriceText.text = _tavernierUpgradePrice.ToString();
        if (Inventory.Instance.richness < _tavernierUpgradePrice) _tavernierButton.interactable = false;
    }
    
    void Update()
    {
        if (Inventory.Instance.richness >= _tavernierUpgradePrice) _tavernierButton.interactable = true;
        else
        {
            _tavernierButton.interactable = false;
        }
    }

    public void UpgradeTavernier()
    {
        if (tavernierLevel < tavernierMaxLevel)
        {
            if (Inventory.Instance.richness >= _tavernierUpgradePrice)
            {
                Inventory.Instance.richness -= _tavernierUpgradePrice;
                _tavernierUpgradePrice *= 2;
                _tavernierUpgradePriceText.text = _tavernierUpgradePrice.ToString();
                
                tavernierLevel++;
                multiplyingFactor = Mathf.Abs(multiplyingFactor *= 2);
                _levelText.text = "Level : " + tavernierLevel.ToString();
            }
            
            if (Inventory.Instance.richness < _tavernierUpgradePrice)
            {
                _tavernierButton.interactable = false;
            }

            if (tavernierLevel == 1)
            {
                tavernierLevel = 1;
                multiplyingFactor = Mathf.Abs(multiplyingFactor *= 2);
                _levelText.text = "Level : " + tavernierLevel.ToString();
                _empoyTextButton.SetActive(false);
                _levelUpButton.SetActive(true);
                StartCoroutine(WorkTavernier());
            }
            
            if (tavernierLevel == tavernierMaxLevel)
            {
                _levelText.text = "Level MAX";
                _tavernierButton.interactable = false;
            }
        }
    }
    
    private void ServeTheGuestByTavernier()
    {
        int valeur = (2 + tavernierLevel) * multiplyingFactor;
        int drakesAmount = valeur;
        
        Debug.Log(drakesAmount);
        
        GameManager.Instance.drakeManager.AddDrake(drakesAmount);
        GameManager.Instance.scoreManager.AddScore(1);
        // Appeler le FeedbackManager pour déclencher un feedback, en passant le GameObject actuel
        GameManager.Instance.feedbackManager.TriggerFeedback(startPosition, moveDirection, drakesAmount, gameObject);
    }
    
    public IEnumerator WorkTavernier()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            ServeTheGuestByTavernier();
        }
        
    }
    
    public IEnumerator LevelUpCooldown()
    {
        _tavernierButton.interactable = false;
        yield return new WaitForSeconds(0.25f);
        _tavernierButton.interactable = true;
        
    }
}
