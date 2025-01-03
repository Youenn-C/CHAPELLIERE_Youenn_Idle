using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TablesPassiveProduction : MonoBehaviour
{
    [SerializeField] private float maxTime; // Temps maximum en secondes
    [SerializeField] private Image filledImage; // Image avec remplissage

    private float currentTime = 0f; // Temps actuel

    private void Start()
    {
        UpdateFilledImage(0f); // Initialise l'image vide
    }

    private void Update()
    {
        if (currentTime <= maxTime)
        {
            currentTime += Time.deltaTime; // Incrémente le temps
            UpdateFilledImage(currentTime / maxTime);
        }
        else
        {
            ResetTimer();
            GameManager.Instance.drakeManager.AddDrake(GameManager.Instance.scoreManager.score);
            GameManager.Instance.drakeManager.UpdateDrakeUI();
        }
    }

    private void UpdateFilledImage(float fillAmount)
    {
        if (filledImage != null)
        {
            // Met à jour le remplissage
            filledImage.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateFilledImage(0f); // Réinitialise l'image vide
    }
}
