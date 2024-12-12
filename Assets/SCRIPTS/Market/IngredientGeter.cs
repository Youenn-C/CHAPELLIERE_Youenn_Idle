using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientGeter : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private Ingredients _ingredientScriptableObject;
    
    [Header("Locals variables"), Space(5)]
    public string ingredientName;
    public int ingedientpurchasePrice;
    public Sprite ingedientImage;
    
    void Start()
    {
        ingredientName = _ingredientScriptableObject.ingredientName;
        ingedientpurchasePrice = _ingredientScriptableObject.ingedientpurchasePrice;
        ingedientImage = _ingredientScriptableObject.ingedientImage;
    }
}
