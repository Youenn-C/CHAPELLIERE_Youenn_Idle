using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Sub Managers"), Space(5)]
    public DrakeManager drakeManager;
    public ScoreManager scoreManager;
    public Upgrade upgrade;
    
    [Header("Settings"), Space(5)]
    [SerializeField] private GameObject _settingsWindow;
    
    [Header("Sound Effect"), Space(5)]
    [SerializeField] private AudioClip _soundEffect;
    [SerializeField] private AudioSource _audioSource;

    
    
    private void Awake()
    {
        // Singleton pour assurer qu'il n'y a qu'une seule instance de ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ServeTheGuest()
    {
        drakeManager.AddDrake(upgrade._defaultClic * upgrade._strength);
        scoreManager.AddScore(2);
        
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
