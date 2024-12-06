using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrakeManager : MonoBehaviour
{
    public static DrakeManager Instance { get; private set; }

    [Header("Drake"), Space(5)]
    [SerializeField] private int richness = 0;
    [SerializeField] private TMP_Text richnessText;

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

    private void Start()
    {
        UpdateDrakeUI();
    }

    public void AddDrake(int amount)
    {
        richness += amount;
        UpdateDrakeUI();

        _audioSource.PlayOneShot(_soundEffect);
    }

    private void UpdateDrakeUI()
    {
        if (richnessText != null)
        {
            richnessText.text = "Drakes : " + richness.ToString();
        }
    }

    public int GetScore()
    {
        return richness;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
