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
    [SerializeField] private int _appleRequired;
    [SerializeField] private int _cherryRequired;
    [SerializeField] private int _pearRequired;
    [Space(5)]
    [SerializeField] private TMP_Text _bottleOfBrandyAmount;
    private int[] brandyIngredientsRequired;
    
    [Header("Wiskey"), Space(5)]
    [SerializeField] private int _cerealsRequired;
    [SerializeField] private int _waterRequired;
    [SerializeField] private int _yeastRequired;
    [Space(5)]
    [SerializeField] private TMP_Text _bottleOfWiskeyAmount;
    private int[] wiskeyIngredientsRequired;
        
    [Header("Cognac"), Space(5)]
    [SerializeField] private int _whiteGrapesRequired;
    [Space(5)]
    [SerializeField] private TMP_Text _bottleOfCognacAmount;
    private int[] cognacIngredientsRequired;
    
    [Header("Grand Marnier"), Space(5)]
    [SerializeField] private int _exoticOrangeEssenceRequired;
    [Space(5)]
    [SerializeField] private TMP_Text _bottleOfGrandMarnierAmount;
    private int[] GrandMarnierIngredientsRequired;
    
    [Header("Absinthe"), Space(5)]
    [SerializeField] private int _lemonBalmRequired;
    [SerializeField] private int _fennelRequired;
    [SerializeField] private int _hyssopRequired;
    [Space(5)]
    [SerializeField] private TMP_Text _bottleOfAbsintheAmount;
    private int[] absintheIngredientsRequired;
    
    void Start()
    {
        brandyIngredientsRequired = new int[] {_appleRequired, _cherryRequired, _pearRequired};
        wiskeyIngredientsRequired = new int[] {_cerealsRequired, _waterRequired, _yeastRequired};
        cognacIngredientsRequired = new int[] {_whiteGrapesRequired};
        GrandMarnierIngredientsRequired = new int[] {_exoticOrangeEssenceRequired};
        absintheIngredientsRequired = new int[] {_lemonBalmRequired, _fennelRequired, _hyssopRequired};
        
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
        int[] requiredAmounts = {_appleRequired, _cherryRequired, _pearRequired};
        int[] availableAmounts = { Inventory.Instance.appleAmount, Inventory.Instance.cherryAmount, Inventory.Instance.pearAmount };
        bool allResourcesSufficient = requiredAmounts.Zip(availableAmounts, (required, available) => available >= required).All(x => x);

        if (allResourcesSufficient)
        {
            Inventory.Instance.appleAmount -= _appleRequired;
            Inventory.Instance.cherryAmount -= _cherryRequired;
            Inventory.Instance.pearAmount -= _pearRequired;
            
            Inventory.Instance.brandyAmount ++;
            
            _bottleOfBrandyAmount.text = "Quantity Owned : " + Inventory.Instance.brandyAmount.ToString();
            
            _audioSource.PlayOneShot(_soundEffect);
        }
    }

    private void UpdateBrandyUI()
    {
        if (appleText != null)
        {
            appleText.text = Inventory.Instance.appleAmount.ToString() + " / " + _appleRequired.ToString();
        }
        
        if (cherryText != null)
        {
            cherryText.text = Inventory.Instance.cherryAmount.ToString() + " / " + _cherryRequired.ToString();
        }
        
        if (pearText != null)
        {
            pearText.text = Inventory.Instance.pearAmount.ToString() + " / " + _pearRequired.ToString();
        }
    }
}