using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Distillery : MonoBehaviour
{
    [Header("Recipe"), Space(5)]
    public MyDictionary<string, ScriptableObject> allAlcoholRecipe = new MyDictionary<string, ScriptableObject>();
    
    [Header("Texts"), Space(5)]
    [SerializeField] private TMP_Text appleText;
    [SerializeField] private TMP_Text cherryText;
    [SerializeField] private TMP_Text pearText;
    
    [Header("Buttons"), Space(5)]
    [SerializeField] private Button brandyBTN;
    
    [Header("Sound"), Space(5)]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundEffect;

    [Header("Brandy"), Space(5)]
    private int brandyAppleRequiwerd = 3;
    private int brandyCherryRequiwerd = 3;
    private int brandyPearRequiwerd = 3;
    
    [Header("Wiskey"), Space(5)]
    private int appleRequiwerd = 3;
    private int cherryRequiwerd = 3;
    private int pearRequiwerd = 3;
    
    /*
    [Header("Brandy"), Space(5)]
    private int appleRequiwerd = 3;
    private int cherryRequiwerd = 3;
    private int pearRequiwerd = 3;
    
    [Header("Brandy"), Space(5)]
    private int appleRequiwerd = 3;
    private int cherryRequiwerd = 3;
    private int pearRequiwerd = 3;
    */
    void Start()
    {
        UpdateBrandyUI();
        // Exemple : Appel à une fonction pour récupérer les noms des ingrédients
        GetIngredientNames("Brandy");
    }

    void Update()
    {
        CheckPreparationOfBrandy();
    }
    
    void CheckPreparationOfBrandy()
    {
        // Déclarez un tableau des quantités requises pour chaque ressource (par exemple, pommes, cerises, poires)
        int[] requiredAmounts = { brandyAppleRequiwerd, brandyCherryRequiwerd, brandyPearRequiwerd};

        // Déclarez un tableau des quantités disponibles dans l'inventaire pour chaque ressource correspondante
        int[] availableAmounts = { Inventory.Instance.appleAmount, Inventory.Instance.cherryAmount, Inventory.Instance.pearAmount };

        // Utilisez la méthode Zip pour combiner les deux tableaux en paires (requises et disponibles), 
        // puis vérifiez pour chaque paire que la quantité disponible est supérieure ou égale à la quantité requise.
        bool allResourcesSufficient = requiredAmounts
            .Zip(availableAmounts, (required, available) => available >= required)  // Vérifie si chaque ressource est suffisante
            .All(x => x);  // Si toutes les ressources sont suffisantes (tous les résultats de "Zip" sont true), alors "allResourcesSufficient" sera true

         // Résultat : "allResourcesSufficient" sera true si toutes les ressources sont suffisantes, sinon false.    


        if (allResourcesSufficient)
        {
            brandyBTN.interactable = true;
        }
        else
        {
            brandyBTN.interactable = false;
        }

        UpdateBrandyUI();
    }

    public void PrepareBrandy()
    {
        int[] requiredAmounts = { brandyAppleRequiwerd, brandyCherryRequiwerd, brandyPearRequiwerd};
        int[] availableAmounts = { Inventory.Instance.appleAmount, Inventory.Instance.cherryAmount, Inventory.Instance.pearAmount };
        bool allResourcesSufficient = requiredAmounts.Zip(availableAmounts, (required, available) => available >= required).All(x => x);

        if (allResourcesSufficient)
        {
            Inventory.Instance.appleAmount -= appleRequiwerd;
            Inventory.Instance.cherryAmount -= cherryRequiwerd;
            Inventory.Instance.pearAmount -= pearRequiwerd;
            
            Inventory.Instance.brandyAmount ++;
            
            _audioSource.PlayOneShot(_soundEffect);
        }
    }

    private void UpdateBrandyUI()
    {
        if (appleText != null)
        {
            appleText.text = Inventory.Instance.appleAmount.ToString() + " / " + 3.ToString();
        }
        
        if (cherryText != null)
        {
            cherryText.text = Inventory.Instance.cherryAmount.ToString() + " / " + 3.ToString();
        }
        
        if (pearText != null)
        {
            pearText.text = Inventory.Instance.pearAmount.ToString() + " / " + 3.ToString();
        }
    }
    
    
    
    
    
    
    
    
    
    void GetIngredientNames(string recipeKey)
    {
        // Vérifier si la clé existe dans le dictionnaire
        if (allAlcoholRecipe.CheckKey(recipeKey))
        {
            // Récupérer l'objet 'AlcoholRecipe' associé à cette clé
            AlcoholRecipe recipe = allAlcoholRecipe[recipeKey] as AlcoholRecipe;

            if (recipe != null)
            {
                // Parcourir la liste des ingrédients
                foreach (var ingredient in recipe.ingredients)
                {
                    // Vérifier si l'ingrédient est bien un ScriptableObject de type attendu
                    if (ingredient != null)
                    {
                        // Afficher le nom de l'ingrédient
                        Debug.Log("Ingredients : " + ingredient.name);
                    }
                }
            }
            else
            {
                Debug.LogError("La recette associée à cette clé n'est pas un 'AlcoholRecipe'.");
            }
        }
        else
        {
            Debug.LogError("La clé de recette spécifiée n'existe pas dans le dictionnaire.");
        }
    }
}