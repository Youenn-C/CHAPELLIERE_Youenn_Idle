using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablesActivator : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private int _tablesLevel;
    
    [Header("Tables"), Space(5)]
    [SerializeField] private GameObject[] tables;
    
    // Start is called before the first frame update
    void Start()
    {
        _tablesLevel = 0;
        
        foreach (var currentTable in tables)
        {
            currentTable.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _tablesLevel = GameManager.Instance.upgrade._tablesCurrentLevel;
        
        if (_tablesLevel == 1)
        {
            tables[_tablesLevel -1 ].SetActive(true);
        }
        
        else if (_tablesLevel == 2)
        {
            tables[_tablesLevel -1 ].SetActive(true);
        }
        
        else if (_tablesLevel == 3)
        {
            tables[_tablesLevel -1 ].SetActive(true);
        }
        
        else if (_tablesLevel == 4)
        {
            tables[_tablesLevel -1 ].SetActive(true);
        }
    }
}
