using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Settings"), Space(5)]
    [SerializeField] private GameObject _settingsWindow;
    
    [Header("Sound Effect"), Space(5)]
    [SerializeField] private AudioClip _soundEffect;
    [SerializeField] private AudioSource _audioSource;
    
    

    public void ServeTheGuest()
    {
        DrakeManager.Instance.AddDrake(2);
        ScoreManager.Instance.AddScore(2);
        
        _audioSource.PlayOneShot(_soundEffect);
    }
    
    public void OpenSettingsWindow()
    {
        _settingsWindow.SetActive(true);
    }
    
    public void CloseSettingsWindow()
    {
        _settingsWindow.SetActive(false);
    }
}
