using System;
using UnityEngine;

public class ContainerMovement : MonoBehaviour
{
    [Header("Referances"), Space(5)]
    [SerializeField] private int _currentPage = 1;
    
    [SerializeField] private Animator _animator;

    public void Go_To_Page_1()
    {
        if (_currentPage == 2)
        {
            _animator.SetTrigger("Page_2_To_Page_1");
            _currentPage = 1;
        }
        
        else if (_currentPage == 3)
        {
            _animator.SetTrigger("Page_3_To_Page_1");
            _currentPage = 1;
        }
    }
    
    public void Go_To_Page_2()
    {
        if (_currentPage == 1)
        {
            _animator.SetTrigger("Page_1_To_Page_2");
            _currentPage = 2;
        }
        
        else if (_currentPage == 3)
        {
            _animator.SetTrigger("Page_3_To_Page_2");
            _currentPage = 2;
        }
    }
    
    public void Go_To_Page_3()
    {
        if (_currentPage == 1)
        {
            _animator.SetTrigger("Page_1_To_Page_3");
            _currentPage = 3;
        }
        
        else if (_currentPage == 2)
        {
            _animator.SetTrigger("Page_2_To_Page_3");
            _currentPage = 3;
        }
    }
}
