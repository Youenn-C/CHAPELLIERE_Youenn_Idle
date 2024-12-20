using UnityEngine;

public class ContainerMovement : MonoBehaviour
{
    [Header("Waypoints"), Space(5)]
    [SerializeField] private RectTransform _position1; // Waypoint 1
    [SerializeField] private RectTransform _position2; // Waypoint 2
    [SerializeField] private RectTransform _position3; // Waypoint 3

    [Header("Settings"), Space(5)]
    [SerializeField] private float speed = 500f; // Vitesse de déplacement (pixels par seconde)

    private RectTransform _mainContainer; // Le conteneur principal
    private RectTransform _targetWaypoint; // Waypoint cible
    private bool _isMoving = false; // Indicateur de déplacement en cours
    
    [SerializeField] private Animator _animator;

    void Start()
    {
        // Initialisation : Conteneur principal et premier waypoint
        _mainContainer = GetComponent<RectTransform>();
        _targetWaypoint = _position1; // Par défaut, on commence au waypoint 1

        // Vérifications des références
        if (_mainContainer == null || _position1 == null || _position2 == null || _position3 == null)
        {
            Debug.LogError("Veuillez assigner tous les RectTransform requis dans l'inspecteur !");
        }
    }

    void Update()
    {
        if (_isMoving)
        {
            MoveTowardsWaypoint();
        }
    }

    // Déplacement vers une page spécifique
    public void GoToPage(int pageNumber)
    {
        if (_isMoving) return; // Empêche un nouveau mouvement si déjà en cours

        // Définir la cible en fonction du numéro de page
        switch (pageNumber)
        {
            case 1:
                _targetWaypoint = _position1;
                break;
            case 2:
                _targetWaypoint = _position2;
                break;
            case 3:
                _targetWaypoint = _position3;
                break;
            default:
                Debug.LogError("Numéro de page invalide !");
                return;
        }

        _isMoving = true; // Début du mouvement
    }

    // Mouvement progressif vers le waypoint cible
    private void MoveTowardsWaypoint()
    {
        // Direction vers la cible
        Vector2 direction = _targetWaypoint.anchoredPosition - _mainContainer.anchoredPosition;

        // Si le conteneur est proche du waypoint, arrêter le déplacement
        if (direction.magnitude < 0.1f)  // Ajuster le seuil pour qu'il soit plus petit
        {
            _mainContainer.anchoredPosition = _targetWaypoint.anchoredPosition; // Alignement précis
            _isMoving = false; // Arrêt du mouvement
            return;
        }

        // Appliquer le mouvement vers la cible avec une décélération progressive
        Vector2 moveStep = direction.normalized * speed * Time.deltaTime;
        _mainContainer.anchoredPosition += moveStep;
    }

    public void Page_1_To_Page_2()
    {
        Debug.Log(_position2.anchoredPosition + _mainContainer.anchoredPosition);
        
        _mainContainer.anchoredPosition = _position2.anchoredPosition;
        _animator.SetTrigger("Page_1_To_Page_2");
    }
}
