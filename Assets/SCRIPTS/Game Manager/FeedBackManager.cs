using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] private FeedBack feedbackPrefab1;  // Préfab du feedback
    [SerializeField] private FeedBack feedbackPrefab2;  // Préfab du feedback

    // Méthode pour déclencher le feedback
    public void TriggerFeedback1(Vector2 startPosition, Vector2 moveDirection, int rewardAmount, GameObject parentObject)
    {
        if (feedbackPrefab1 == null)
        {
            Debug.LogError("Feedback prefab is not assigned!");
            return;
        }

        // Instancier un feedback à la position spécifiée, comme enfant du parent
        FeedBack feedbackInstance = Instantiate(feedbackPrefab1, startPosition, Quaternion.identity);

        // Rendre l'instance enfant du GameObject appelant
        feedbackInstance.transform.SetParent(parentObject.transform);

        if (feedbackInstance != null)
        {
            feedbackInstance.InitializeFeedback(rewardAmount, moveDirection);
            feedbackInstance.gameObject.SetActive(true);

            // Lancer la coroutine pour le mouvement, le fade et la destruction après
            feedbackInstance.StartCoroutine(feedbackInstance.MoveAndFade(moveDirection, parentObject));
        }
    }
    
    public void TriggerFeedback2(Vector2 startPosition, Vector2 moveDirection, int rewardAmount, GameObject parentObject)
    {
        if (feedbackPrefab2 == null)
        {
            Debug.LogError("Feedback prefab is not assigned!");
            return;
        }

        // Instancier un feedback à la position spécifiée, comme enfant du parent
        FeedBack feedbackInstance = Instantiate(feedbackPrefab2, startPosition, Quaternion.identity);

        // Rendre l'instance enfant du GameObject appelant
        feedbackInstance.transform.SetParent(parentObject.transform);

        if (feedbackInstance != null)
        {
            feedbackInstance.InitializeFeedback(rewardAmount, moveDirection);
            feedbackInstance.gameObject.SetActive(true);

            // Lancer la coroutine pour le mouvement, le fade et la destruction après
            feedbackInstance.StartCoroutine(feedbackInstance.MoveAndFade(moveDirection, parentObject));
        }
    }
}