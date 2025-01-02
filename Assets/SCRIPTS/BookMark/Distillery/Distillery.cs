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
    [SerializeField] private Button whiskeyBTN;
    [SerializeField] private Button cognacBTN;
    [SerializeField] private Button grandMarnierBTN;
    [SerializeField] private Button absintheBTN;

    [Header("Sound"), Space(5)]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundEffect;

    [Header("Alcohol Requirements"), Space(5)]
    [SerializeField] private AlcoholRequirements[] alcoholRequirements;

    void Start()
    {
        foreach (var alcohol in alcoholRequirements)
        {
            alcohol.InitializeUI();
        }
    }

    void Update()
    {
        foreach (var alcohol in alcoholRequirements)
        {
            alcohol.CheckPreparation();
        }
    }

    public void PrepareAlcohol(string alcoholName)
    {
        var alcohol = alcoholRequirements.FirstOrDefault(a => a.alcoholName == alcoholName);
        if (alcohol != null)
        {
            alcohol.Prepare(_audioSource, _soundEffect);
        }
    }
}

[System.Serializable]
public class AlcoholRequirements
{
    public string alcoholName;
    public TMP_Text[] ingredientTexts;
    public string[] ingredientNames;
    public int[] requiredAmounts;
    public TMP_Text bottleAmountText;
    public Button prepareButton;

    public void InitializeUI()
    {
        UpdateUI();
    }

    public void CheckPreparation()
    {
        bool allResourcesSufficient = requiredAmounts
            .Select((required, index) => Inventory.Instance.GetIngredientQuantity(ingredientNames[index]) >= required)
            .All(x => x);

        prepareButton.interactable = allResourcesSufficient;
        UpdateUI();
    }

    public void Prepare(AudioSource audioSource, AudioClip soundEffect)
    {
        bool allResourcesSufficient = requiredAmounts
            .Select((required, index) => Inventory.Instance.GetIngredientQuantity(ingredientNames[index]) >= required)
            .All(x => x);

        if (allResourcesSufficient)
        {
            for (int i = 0; i < requiredAmounts.Length; i++)
            {
                Inventory.Instance.IncrementIngredient(ingredientNames[i]);
                Inventory.Instance.DecrementIngredient(ingredientNames[i], requiredAmounts[i]);
            }

            switch (alcoholName)
            {
                case "brandy":
                    Inventory.Instance.brandyAmount++;
                    break;
                case "wiskey":
                    Inventory.Instance.wiskeyAmount++;
                    break;
                case "cognac":
                    Inventory.Instance.cognacAmount++;
                    break;
                case "grandMarnier":
                    Inventory.Instance.grandMarnierAmount++;
                    break;
                case "absinthe":
                    Inventory.Instance.absintheAmount++;
                    break;
            }

            int alcoholQuantity = alcoholName switch
            {
                "brandy" => Inventory.Instance.brandyAmount,
                "wiskey" => Inventory.Instance.wiskeyAmount,
                "cognac" => Inventory.Instance.cognacAmount,
                "grandMarnier" => Inventory.Instance.grandMarnierAmount,
                "absinthe" => Inventory.Instance.absintheAmount,
                _ => 0 // Si un nom d'alcool non reconnu est fourni, la valeur par défaut est 0
            };
            bottleAmountText.text = $"Quantity Owned: {alcoholQuantity}";

            audioSource.PlayOneShot(soundEffect);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < ingredientTexts.Length; i++)
        {
            if (ingredientTexts[i] != null)
            {
                ingredientTexts[i].text = $"{Inventory.Instance.GetIngredientQuantity(ingredientNames[i])} / {requiredAmounts[i]}";
            }
        }
    }
}
