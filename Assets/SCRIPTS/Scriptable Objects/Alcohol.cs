using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_Alcohol", menuName = "Alcohol", order = 0)]
public class Alcohol : ScriptableObject
{
    public string alcoholName;
    public int alcoholPurchasePrice;
    public AlcoholIngredients[] alcoholIngredients;
    public Sprite alcoholImage;
}
