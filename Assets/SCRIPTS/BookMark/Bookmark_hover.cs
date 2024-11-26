using UnityEngine;
using UnityEngine.EventSystems;

public class Bookmark_hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 moveDirection = new Vector2(100f, 0f); // Direction et distance du déplacement
    public float slideSpeed = 5f; // Vitesse de glissement

    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private Vector2 _targetPosition; // Position vers laquelle le bouton glisse
    private bool _isHovering = false;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;
        _targetPosition = _originalPosition;
    }

    void Update()
    {
        // Interpolation de la position pour créer un effet de glissement
        _rectTransform.anchoredPosition = Vector2.Lerp(_rectTransform.anchoredPosition, _targetPosition, Time.deltaTime * slideSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Définir la nouvelle position cible lors du survol
        _targetPosition = _originalPosition + moveDirection;
        _isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revenir à la position d'origine lorsque la souris quitte la zone
        _targetPosition = _originalPosition;
        _isHovering = false;
    }
}
