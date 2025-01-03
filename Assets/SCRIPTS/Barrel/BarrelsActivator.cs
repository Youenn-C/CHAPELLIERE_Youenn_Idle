using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsActivator : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private int _barrelLevel;
    
    [Header("_barrels"), Space(5)]
    [SerializeField] private GameObject[] _barrels;
    
    // Start is called before the first frame update
    void Start()
    {
        _barrelLevel = 0;
        
        foreach (var currentTable in _barrels)
        {
            currentTable.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _barrelLevel = GameManager.Instance.upgrade._barrelCurrentLevel;
        
        if (_barrelLevel == 1)
        {
            _barrels[_barrelLevel -1 ].SetActive(true);
        }
        
        else if (_barrelLevel == 2)
        {
            _barrels[_barrelLevel -1 ].SetActive(true);
        }
        
        else if (_barrelLevel == 3)
        {
            _barrels[_barrelLevel -1 ].SetActive(true);
        }
        
        else if (_barrelLevel == 4)
        {
            _barrels[_barrelLevel -1 ].SetActive(true);
        }
        
        else if (_barrelLevel == 5)
        {
            _barrels[_barrelLevel -1 ].SetActive(true);
        }
    }
}
