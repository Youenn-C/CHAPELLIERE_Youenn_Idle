using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings"), Space(5)]
    [SerializeField] private GameObject _settingsWindow;

    public void OpenSettingsWindow()
    {
        _settingsWindow.SetActive(true);
    }
    
    public void CloseSettingsWindow()
    {
        _settingsWindow.SetActive(false);
    }
}
