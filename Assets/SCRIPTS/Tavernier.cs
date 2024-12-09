using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Tavernier : MonoBehaviour
{
    [SerializeField] private GameObject _empoyTextButton;
    [SerializeField] private GameObject _levelUpButton;
    [SerializeField] private int tavernierLevel;
    [SerializeField] private int multiplyingFactor = 1;
    // Start is called before the first frame update
    void Start()
    {
        _empoyTextButton.SetActive(true);
        _levelUpButton.SetActive(false);
        tavernierLevel = 0;
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
    }
    
    private void ServeTheGuestByTavernier()
    {
        float valeur = (2 + tavernierLevel) * multiplyingFactor;
        int drakesAmount = (int)Math.Round(valeur, MidpointRounding.AwayFromZero);
        
        Debug.Log(drakesAmount);
        
        DrakeManager.Instance.AddDrake(drakesAmount);
        ScoreManager.Instance.AddScore(1);
    }
    
    public IEnumerator WorkTavernier()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            ServeTheGuestByTavernier();
        }
        
    }
}
