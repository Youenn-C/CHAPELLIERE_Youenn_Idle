using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_Ingredient", menuName = "Ingredient", order = 0)]
public class Ingredients : ScriptableObject
{
    public string ingedientName;
    public int ingedientpurchasePrice;
    public int ingedientsellingPrice;
    public Sprite ingedientImage;
}
