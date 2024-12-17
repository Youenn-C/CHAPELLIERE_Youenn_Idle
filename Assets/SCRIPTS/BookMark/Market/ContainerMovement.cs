using UnityEngine;

public class ContainerMovement : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private GameObject _mainContainer;
    
    [Header("Variables"), Space(5)] 
    [SerializeField] private int _currentPosition;
    [SerializeField] private Transform[] _positions;
    
    [Header("Animations"), Space(5)]
    [SerializeField] private Animator _animator;

    void Start()
    {
        // Récupère l'Animator attaché au GameObject parent
        _animator = GetComponent<Animator>();
        _animator.applyRootMotion = false;
        _currentPosition = 1;
    }

    // Déplacement vers la gauche
    public void MoveLeft()
    {
        if (_currentPosition > 1)
        {
            int targetPosition = _currentPosition - 1; // Position cible
            PlayAnimation(_currentPosition, targetPosition);
            _currentPosition = targetPosition; // Met à jour la position actuelle
            transform.position = _positions[_currentPosition - 1].position;
        }
    }

    // Déplacement vers la droite
    public void MoveRight()
    {
        if (_currentPosition < 3)
        {
            int targetPosition = _currentPosition + 1; // Position cible
            PlayAnimation(_currentPosition, targetPosition);
            _currentPosition = targetPosition; // Met à jour la position actuelle
            Debug.Log(_positions[_currentPosition + 1].position);
        }
    }

    // Déclenche le déplacement
    private void PlayAnimation(int from, int to)
    {
        if (_animator != null)
        {
            // Détermine le nom du trigger à activer (par exemple, "Move_1_to_2")
            string triggerName = $"Move_{from}_to_{to}";
            _animator.SetTrigger(triggerName);
        }
    }
    
    // Appelée à la fin de l'animation via un événement
    private void UpdatePositionToTarget()
    {
        // Déplace explicitement à la position finale
        transform.position = _positions[_currentPosition - 1].position;

    }
}
