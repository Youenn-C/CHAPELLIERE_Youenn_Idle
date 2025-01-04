using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] private FeedBack feedbackPrefab;  // Préfab du feedback

    // Méthode pour déclencher le feedback
    public void TriggerFeedback(Vector2 startPosition, Vector2 moveDirection, int rewardAmount, GameObject parentObject)
    {
        if (feedbackPrefab == null)
        {
            Debug.LogError("Feedback prefab is not assigned!");
            return;
        }

        // Instancier un feedback à la position spécifiée, comme enfant du parent
        FeedBack feedbackInstance = Instantiate(feedbackPrefab, startPosition, Quaternion.identity);

        // Rendre l'instance enfant du GameObject appelant
        feedbackInstance.transform.SetParent(parentObject.transform);

        if (feedbackInstance != null)
        {
            feedbackInstance.InitializeFeedback(rewardAmount, moveDirection);
            feedbackInstance.gameObject.SetActive(true);

            // Lancer la coroutine pour le mouvement, le fade et la destruction après
            feedbackInstance.StartCoroutine(feedbackInstance.MoveAndFade(moveDirection, parentObject));
        }
        else
        {
            Debug.LogError("Failed to instantiate Feedback!");
        }
    }
}