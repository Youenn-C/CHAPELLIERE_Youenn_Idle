using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SellIngredients : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _quantityText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int _price;
    [SerializeField] private Button _buyButton;
    [SerializeField] private string _ingredientPurchased;
    
    [SerializeField] private IngredientGeter _ingredientGeter; 
    private void Start()
    {
        _nameText.text = _ingredientGeter.ingredientName;
        _priceText.text = _ingredientGeter.ingedientpurchasePrice.ToString();
        _price = _ingredientGeter.ingedientpurchasePrice;
        UpdateQuantityText();
        Debug.Log(_ingredientGeter.ingredientName);
        Debug.Log(_nameText);
    }

    public void Buy()
    {
        // Vérifie si le joueur a assez de richesse
        if (Inventory.Instance.richness >= _price)
        {
            // Déduit l'argent du joueur
            Inventory.Instance.richness -= _price;

            // Appelle la méthode pour incrémenter la quantité de l'ingrédient spécifié
            Inventory.Instance.IncrementIngredient(_ingredientPurchased);;

            // Met à jour l'affichage de la quantité de l'ingrédient
            UpdateQuantityText();
        }
    }
    
    private void UpdateQuantityText()
    {
        int currentQuantity = Inventory.Instance.GetIngredientQuantity(_ingredientPurchased);
        _quantityText.text = "Quantité possédée : " + currentQuantity.ToString();
    }
}
