using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanScrollbar : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float scrollbarValue;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollbarValue = scrollbar.value;
    }

    // Update is called once per frame
    void Update()
    {
        scrollbarValue = scrollbar.value;
    }
}
