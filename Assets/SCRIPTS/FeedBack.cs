using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class FeedBack : MonoBehaviour
{
    [SerializeField] private TMP_Text feedbackText;
    [SerializeField] private Image feedbackImage;
    [SerializeField] private CanvasGroup canvasGroup;  // Référence au CanvasGroup pour gérer l'opacité

    private Vector2 moveDirection;
    private int rewardAmount;

    // Méthode pour initialiser le feedback
    public void InitializeFeedback(int amount, Vector2 direction)
    {
        rewardAmount = amount;
        moveDirection = direction;

        UpdateFeedbackText();
    }

    // Méthode pour mettre à jour le texte du feedback
    private void UpdateFeedbackText()
    {
        if (feedbackText != null)
        {
            feedbackText.text = "+ " + rewardAmount.ToString();
        }
    }

    // Coroutine pour gérer le mouvement, le fade, et la destruction
    public IEnumerator MoveAndFade(Vector2 direction, GameObject parentObject)
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + direction;

        float moveDuration = 1f;  // Durée du mouvement
        float fadeDuration = 1f;  // Durée du fade
        float elapsedTime = 0f;

        // Assurez-vous que le CanvasGroup est valide
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        // Si aucun CanvasGroup n'est trouvé, on ne fait pas de fade
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup is missing on the feedback object!");
            yield break;
        }

        // Déplacer l'objet progressivement
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);  // Fade vers 0
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assurez-vous que la position finale est bien atteinte
        transform.position = targetPosition;
        canvasGroup.alpha = 0f;  // Finaliser le fade

        // Détruire le feedback après le fade et le mouvement
        Destroy(gameObject);
    }
}
