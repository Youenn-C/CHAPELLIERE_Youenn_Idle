using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IN_", menuName = "Ingredient", order = 0)]
public class Ingredients : ScriptableObject
{
    public string ingredientName;
    public int ingedientpurchasePrice;
    public Sprite ingedientImage;
}
