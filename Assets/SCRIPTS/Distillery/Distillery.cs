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
    [Space(5)]
    [SerializeField] private TMP_Text cerealsText;
    [SerializeField] private TMP_Text waterText;
    [SerializeField] private TMP_Text yeastText;
    [Space(5)]
    [SerializeField] private TMP_Text whiteGrapesText;
    [Space(5)]
    [SerializeField] private TMP_Text exoticOrangesText;
    [Space(5)]
    [SerializeField] private TMP_Text lemonBalmText;
    [SerializeField] private TMP_Text fennelText;
    [SerializeField] private TMP_Text hyssopText;
    
    
    [Header("Buttons"), Space(5)]
    [SerializeField] private Button brandyBTN;
    [Space(5)]
    [SerializeField] private Button whiskeyBTN;
    [Space(5)]
    [SerializeField] private Button cognacBTN;
    [Space(5)]
    [SerializeField] private Button grandMarnierBTN;
    [Space(5)]
    [SerializeField] private Button absintheBTN;
    
    [Header("Sound"), Space(5)]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundEffect;

    // -------------------------------------------------------------
    
    [Header("Brandy"), Space(5)]
    [SerializeField] private int appleRequired;
    [SerializeField] private int cherryRequired;
    [SerializeField] private int pearRequired;
    [Space(5)]
    [SerializeField] private TMP_Text bottleOfBrandyAmount;
    private int[] brandyIngredientsRequired;
    
    [Header("Wiskey"), Space(5)]
    [SerializeField] private int cerealsRequired;
    [SerializeField] private int waterRequired;
    [SerializeField] private int yeastRequired;
    [Space(5)]
    [SerializeField] private TMP_Text bottleOfWiskeyAmount;
    private int[] wiskeyIngredientsRequired;
        
    [Header("Cognac"), Space(5)]
    [SerializeField] private int whiteGrapesRequired;
    [Space(5)]
    [SerializeField] private TMP_Text bottleOfCognacAmount;
    private int[] cognacIngredientsRequired;
    
    [Header("Grand Marnier"), Space(5)]
    [SerializeField] private int exoticOrangeEssenceRequired;
    [Space(5)]
    [SerializeField] private TMP_Text bottleOfGrandMarnierAmount;
    private int[] GrandMarnierIngredientsRequired;
    
    [Header("Absinthe"), Space(5)]
    [SerializeField] private int lemonBalmRequired;
    [SerializeField] private int fennelRequired;
    [SerializeField] private int hyssopRequired;
    [Space(5)]
    [SerializeField] private TMP_Text bottleOfAbsintheAmount;
    private int[] absintheIngredientsRequired;
    
    void Start()
    {
        brandyIngredientsRequired = new int[] {appleRequired, cherryRequired, pearRequired};
        wiskeyIngredientsRequired = new int[] {cerealsRequired, waterRequired, yeastRequired};
        cognacIngredientsRequired = new int[] {whiteGrapesRequired};
        GrandMarnierIngredientsRequired = new int[] {exoticOrangeEssenceRequired};
        absintheIngredientsRequired = new int[] {lemonBalmRequired, fennelRequired, hyssopRequired};
        
        UpdateBrandyUI();
    }

    void Update()
    {
        CheckPreparationForBrandy();
    }
    
    void CheckPreparationForBrandy()
    {
        // Déclarez un tableau des quantités disponibles dans l'inventaire pour chaque ressource correspondante
        int[] availableAmounts = { Inventory.Instance.appleAmount, Inventory.Instance.cherryAmount, Inventory.Instance.pearAmount };

        // Utilisez la méthode Zip pour combiner les deux tableaux en paires (requises et disponibles), puis vérifiez pour chaque paire que la quantité disponible est supérieure ou égale à la quantité requise.
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
            appleText.text = Inventory.Instance.appleAmount.ToString() + " / " + appleRequired.ToString();
        }
        
        if (cherryText != null)
        {
            cherryText.text = Inventory.Instance.cherryAmount.ToString() + " / " + cherryRequired.ToString();
        }
        
        if (pearText != null)
        {
            pearText.text = Inventory.Instance.pearAmount.ToString() + " / " + pearRequired.ToString();
        }
    }
}