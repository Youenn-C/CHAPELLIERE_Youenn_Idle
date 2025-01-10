using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Sub Managers"), Space(5)]
    public DrakeManager drakeManager;
    public ScoreManager scoreManager;
    public Upgrade upgrade;
    public FeedbackManager feedbackManager;

    [Header("Settings"), Space(5)]
    [SerializeField] private GameObject _settingsWindow;

    [Header("Sound Effect"), Space(5)]
    [SerializeField] private AudioClip _soundEffect;
    [SerializeField] private AudioSource _audioSource;

    [Header("Music Settings"), Space(5)]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private AudioSource[] _musicAudioSources; // Two AudioSources for music

    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Toggle _sfxToggle;
    [SerializeField] private AudioSource _sfxAudioSource; // One AudioSource for sound effects

    [Header("Variables"), Space(5)]
    public float priceMultiplier = 1;
    
    [Header("FeedBack Data"), Space(5)]
    [SerializeField] private int rewardAmount;
    private Vector2 startPosition;
    [SerializeField] private Vector2 moveDirection;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize sliders and toggles
        if (_musicSlider != null)
        {
            _musicSlider.onValueChanged.AddListener(SetMusicVolume);
            _musicSlider.value = 0.5f;
        }

        if (_musicToggle != null)
        {
            _musicToggle.onValueChanged.AddListener(ToggleMusic);
            _musicToggle.isOn = _musicAudioSources.Length > 0 && _musicAudioSources[0].mute;
        }

        if (_sfxSlider != null)
        {
            _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
            _sfxSlider.value = 0.5f;
        }

        if (_sfxToggle != null)
        {
            _sfxToggle.onValueChanged.AddListener(ToggleSFX);
            _sfxToggle.isOn = _sfxAudioSource != null && _sfxAudioSource.mute;
        }
    }

    public void ServeTheGuest()
    {
        int amount = Mathf.Abs(upgrade._defaultClic * upgrade._strength);
        drakeManager.AddDrake(amount);
        scoreManager.AddScore(2);

        if (_sfxAudioSource != null && !_sfxAudioSource.mute)
        {
            _sfxAudioSource.PlayOneShot(_soundEffect);
        }
    }

    public void ToggleSettingsWindow()
    {
        _settingsWindow.SetActive(!_settingsWindow.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetMusicVolume(float volume)
    {
        foreach (var audioSource in _musicAudioSources)
        {
            audioSource.volume = volume;
        }
    }

    private void ToggleMusic(bool isMuted)
    {
        foreach (var audioSource in _musicAudioSources)
        {
            audioSource.mute = isMuted;
        }
    }

    private void SetSFXVolume(float volume)
    {
        if (_sfxAudioSource != null)
        {
            _sfxAudioSource.volume = volume;
        }
    }

    private void ToggleSFX(bool isMuted)
    {
        if (_sfxAudioSource != null)
        {
            _sfxAudioSource.mute = isMuted;
        }
    }
}
