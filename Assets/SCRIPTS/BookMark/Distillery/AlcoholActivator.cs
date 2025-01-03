using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholActivator : MonoBehaviour
{
    [Header("Alcohol Panels"), Space(5)]
    [SerializeField] private GameObject _panelAlcohol1;
    [SerializeField] private GameObject _panelAlcohol2;
    [SerializeField] private GameObject _panelAlcohol3;
    [SerializeField] private GameObject _panelAlcohol4;
    [SerializeField] private GameObject _panelAlcohol5;

    [SerializeField] private int _barrelLevel;
    // Start is called before the first frame update
    void Start()
    {
        _barrelLevel = GameManager.Instance.upgrade._barrelCurrentLevel;
        
        _panelAlcohol1.SetActive(false);
        _panelAlcohol2.SetActive(false);
        _panelAlcohol3.SetActive(false);
        _panelAlcohol4.SetActive(false);
        _panelAlcohol5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _barrelLevel = GameManager.Instance.upgrade._barrelCurrentLevel;

        if (_barrelLevel == 1)
        {
            _panelAlcohol1.SetActive(true);
        }
        
        else if (_barrelLevel == 2)
        {
            _panelAlcohol2.SetActive(true);
        }
        
        else if (_barrelLevel == 3)
        {
            _panelAlcohol3.SetActive(true);
        }
        
        else if (_barrelLevel == 4)
        {
            _panelAlcohol4.SetActive(true);
        }
        
        else if (_barrelLevel == 5)
        {
            _panelAlcohol5.SetActive(true);
        }
    }
}
