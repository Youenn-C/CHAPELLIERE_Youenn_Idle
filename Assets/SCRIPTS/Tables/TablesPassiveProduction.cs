using UnityEngine;
using UnityEngine.UI;

public class TablesPassiveProduction : MonoBehaviour
{
    [SerializeField] private float maxTime;  // Temps maximum en secondes
    [SerializeField] private Image filledImage;  // Image avec remplissage

    private float currentTime = 0f;  // Temps actuel

    [Header("FeedBack Data"), Space(5)]
    [SerializeField] private int rewardAmount;
    private Vector2 startPosition;
    [SerializeField] private Vector2 moveDirection;

    private void Start()
    {
        startPosition = transform.position;
        
        UpdateFilledImage(0f);  // Initialise l'image vide
    }

    private void Update()
    {
        if (currentTime <= maxTime)
        {
            currentTime += Time.deltaTime;  // Incrémente le temps
            UpdateFilledImage(currentTime / maxTime);
        }
        else
        {
            ResetTimer();
            rewardAmount = GameManager.Instance.scoreManager.score / 2;
            GameManager.Instance.drakeManager.AddDrake(rewardAmount);
            GameManager.Instance.drakeManager.UpdateDrakeUI();

            // Appeler le FeedbackManager pour déclencher un feedback, en passant le GameObject actuel
            GameManager.Instance.feedbackManager.TriggerFeedback1(startPosition, moveDirection, rewardAmount, gameObject);
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
        UpdateFilledImage(0f);  // Réinitialise l'image vide
    }
}