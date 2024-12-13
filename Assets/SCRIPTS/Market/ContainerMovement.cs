using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMovement : MonoBehaviour
{
    [Header("Variables"), Space(5)] 
    [SerializeField] private int _containerIndinceFollow;
    
    [Header("Animations"), Space(5)]
    [SerializeField] private Animation _pos1IntoPos2;
    [SerializeField] private Animation _pos2IntoPos3;
    [Space(3)]
    [SerializeField] private Animation _pos2IntoPos1;
    [SerializeField] private Animation _pos3IntoPos2;
    
    void Start()
    {
        _containerIndinceFollow = 0;
    }

    public void MoveContainerToRight()
    {
        if (_containerIndinceFollow == 0)
        {
            _containerIndinceFollow++;
            _pos1IntoPos2.Play();
        }
        
        if (_containerIndinceFollow == 1)
        {
            _containerIndinceFollow++;
            _pos2IntoPos3.Play();
        }
    }
    
    public void MoveContainerToLeft()
    {
        if (_containerIndinceFollow == 1)
        {
            _containerIndinceFollow--;
            _pos2IntoPos1.Play();
        }
        
        if (_containerIndinceFollow == 2)
        {
            _containerIndinceFollow++;
            _pos3IntoPos2.Play();
        }
    }
}
