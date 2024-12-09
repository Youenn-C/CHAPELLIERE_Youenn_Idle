using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.PlayerLoop;

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

    // -------------------------------------------------------------
    
    [Header("Brandy"), Space(5)]
    [SerializeField] private int appleRequired;
    [SerializeField] private int cherryRequired;
    [SerializeField] private int pearRequired;
    [SerializeField] private TMP_Text bottleOfBrandyAmount;
    private int[] brandyIngredientsRequired;
    
    [Header("Wiskey"), Space(5)]
    [SerializeField] private int cerealsRequired;
    [SerializeField] private int waterRequired;
    [SerializeField] private int yeastRequired;
    private int[] wiskeyIngredientsRequired;
        
    [Header("Cognac"), Space(5)]
    [SerializeField] private int whiteGrapesRequired;
    private int[] cognacIngredientsRequired;
    
    [Header("Grand Marnier"), Space(5)]
    [SerializeField] private int exoticOrangeEssenceRequired;
    private int[] GrandMarnierIngredientsRequired;
    
    [Header("Absinthe"), Space(5)]
    [SerializeField] private int largeWormwoodRequired;
    [SerializeField] private int smallWormwoodRequired;
    [SerializeField] private int greenAniseRequired;
    [SerializeField] private int fennelRequired;
    [SerializeField] private int lemonBalmRequired;
    [SerializeField] private int hyssopRequired;
    private int[] absintheIngredientsRequired;
    
    void Start()
    {
        UpdateBrandyUI();
        InitializationOfIngredients();
    }

    void Update()
    {
        CheckPreparation();
    }

    void InitializationOfIngredients()
    {
        brandyIngredientsRequired = new int[] {appleRequired, cherryRequired, pearRequired};
        wiskeyIngredientsRequired = new int[] {cerealsRequired, waterRequired, yeastRequired};
        cognacIngredientsRequired = new int[] {whiteGrapesRequired};
        GrandMarnierIngredientsRequired = new int[] {exoticOrangeEssenceRequired};
        absintheIngredientsRequired = new int[] {largeWormwoodRequired, smallWormwoodRequired, greenAniseRequired, fennelRequired, lemonBalmRequired, hyssopRequired};
    }
    
    void CheckPreparation()
    {
        // Déclarez un tableau des quantités requises pour chaque ressource (par exemple, pommes, cerises, poires)
        //int[] requiredAmounts = { brandyAppleRequired, brandyCherryRequired, brandyPearRequired};

        // Déclarez un tableau des quantités disponibles dans l'inventaire pour chaque ressource correspondante
        int[] availableAmounts = { Inventory.Instance.appleAmount, Inventory.Instance.cherryAmount, Inventory.Instance.pearAmount };

        // Utilisez la méthode Zip pour combiner les deux tableaux en paires (requises et disponibles), 
        // puis vérifiez pour chaque paire que la quantité disponible est supérieure ou égale à la quantité requise.
        bool allResourcesSufficient = brandyIngredientsRequired
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
        int[] requiredAmounts = {appleRequired, cherryRequired, pearRequired};
        int[] availableAmounts = { Inventory.Instance.appleAmount, Inventory.Instance.cherryAmount, Inventory.Instance.pearAmount };
        bool allResourcesSufficient = requiredAmounts.Zip(availableAmounts, (required, available) => available >= required).All(x => x);

        if (allResourcesSufficient)
        {
            Inventory.Instance.appleAmount -= appleRequired;
            Inventory.Instance.cherryAmount -= cherryRequired;
            Inventory.Instance.pearAmount -= pearRequired;
            
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