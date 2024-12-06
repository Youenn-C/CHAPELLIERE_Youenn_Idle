using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AR_", menuName = "Recipe", order = 0)]
public class AlcoholRecipe : ScriptableObject
{
    public string recipeName;
    public ScriptableObject[] ingredients;
    public Sprite ingedientImage;
}