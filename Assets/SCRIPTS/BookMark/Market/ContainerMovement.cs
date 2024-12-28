using System;
using UnityEngine;
using UnityEngine.UI;

public class ContainerMovement : MonoBehaviour
{
    [Header("Referances"), Space(5)]
    [SerializeField] private int _currentPage = 1;
    [SerializeField] private GameObject _containerMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _button1, _button2, _button3;

    void Start()
    {
        _animator = _containerMovement.GetComponent<Animator>();
    }
    
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
        _button1.interactable = false;
        _button2.interactable = true;
        _button3.interactable = true;
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
        _button1.interactable = true;
        _button2.interactable = false;
        _button3.interactable = true;
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
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = false;
    }

    public void ResetCurrentPage()
    {
        if (_currentPage != 1) _currentPage = 1;
        _button1.interactable = false;
        _button2.interactable = true;
        _button3.interactable = true;
    }
}
