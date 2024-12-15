using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SellIngredients : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private TMP_Text _nameText;  // Affichage du nom
    [SerializeField] private TMP_Text _quantityText;  // Affichage de la quantité
    [SerializeField] private TMP_Text _priceText;  // Affichage du prix
    private int _price;  // Le prix de l'ingrédient
    [SerializeField] private Button _buyButton;  // Le bouton d'achat
    [SerializeField] private string _ingredientPurchased;  // Nom de l'ingrédient acheté
    
    [SerializeField] private IngredientGeter _ingredientGeter;  // Référence au script IngredientGeter

    private void Start()
    {
        // Récupère le nom de l'ingrédient depuis le script IngredientGeter
        _nameText.text = _ingredientGeter.ingredientNameSTRING;  // Utilisation de ingredientNameSTRING, pas de TMP_Text
        _priceText.text = _ingredientGeter.ingedientpurchasePrice.ToString();  // Affiche le prix
        _price = _ingredientGeter.ingedientpurchasePrice;  // Définit le prix de l'ingrédient
        UpdateQuantityText();  // Met à jour la quantité affichée

        // Pour déboguer (facultatif)
        Debug.Log(_ingredientGeter.ingredientNameSTRING);
        Debug.Log(_nameText.text);  // Affiche le texte du nom de l'ingrédient dans le Debug
    }

    public void Buy()
    {
        // Vérifie si le joueur a suffisamment de richesse
        if (Inventory.Instance.richness >= _price)
        {
            // Déduit l'argent du joueur
            Inventory.Instance.richness -= _price;

            // Appelle la méthode pour incrémenter la quantité de l'ingrédient
            Inventory.Instance.IncrementIngredient(_ingredientPurchased);
            
            GameManager.Instance.drakeManager.UpdateDrakeUI();

            // Met à jour l'affichage de la quantité de l'ingrédient
            UpdateQuantityText();
        }
    }
    
    private void UpdateQuantityText()
    {
        // Récupère la quantité actuelle de l'ingrédient et l'affiche
        int currentQuantity = Inventory.Instance.GetIngredientQuantity(_ingredientPurchased);
        _quantityText.text = "Possédé : " + currentQuantity.ToString();
    }
}