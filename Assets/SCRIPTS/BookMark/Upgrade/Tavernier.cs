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
    [SerializeField] private TMP_Text _levelText;
    
    // Start is called before the first frame update
    void Start()
    {
        _empoyTextButton.SetActive(true);
        _levelUpButton.SetActive(false);
        tavernierLevel = 0;
        _levelText.text = "Inactif";
    }

    public void UpgradeTavernier()
    {
        if (tavernierLevel < tavernierMaxLevel)
        {
            tavernierLevel++;
            multiplyingFactor = Mathf.Abs(multiplyingFactor *= 2);
            _levelText.text = "Lvl : " + tavernierLevel.ToString();

            if (tavernierLevel == 1)
            {
                tavernierLevel = 1;
                multiplyingFactor = Mathf.Abs(multiplyingFactor *= 2);
                _levelText.text = "Lvl : " + tavernierLevel.ToString();
                _empoyTextButton.SetActive(false);
                _levelUpButton.SetActive(true);
                StartCoroutine(WorkTavernier());
            }
            
            if (tavernierLevel >= tavernierMaxLevel)
            {
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
