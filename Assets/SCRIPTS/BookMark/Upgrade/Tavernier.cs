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
        if (1 <= tavernierLevel) tavernierLevel++;
        else if (tavernierLevel == 0)
        {
            tavernierLevel = 1;
            _empoyTextButton.SetActive(false);
            _levelUpButton.SetActive(true);
            StartCoroutine(WorkTavernier());
        }
        multiplyingFactor *= 2;

        StartCoroutine(LevelUpCooldown());
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
        _levelText.text = "Lvl : " + tavernierLevel.ToString();
    }
}
