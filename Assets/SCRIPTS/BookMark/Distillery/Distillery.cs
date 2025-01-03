using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Distillery : MonoBehaviour
{
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
        DistilleryUpdateUI();
        UpdateBottleQuantityUI(); // Mise à jour initiale de la quantité de bouteilles
    }

    public void CheckPreparation()
    {
        bool allResourcesSufficient = requiredAmounts
            .Select((required, index) => Inventory.Instance.GetIngredientQuantity(ingredientNames[index]) >= required)
            .All(x => x);

        prepareButton.interactable = allResourcesSufficient;

        DistilleryUpdateUI();
        UpdateBottleQuantityUI(); // Mise à jour continue de la quantité de bouteilles
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
                int currentQuantity = Inventory.Instance.GetIngredientQuantity(ingredientNames[i]);
                int requiredQuantity = requiredAmounts[i];

                Inventory.Instance.DecrementIngredient(ingredientNames[i], requiredQuantity);
            }

            // Mise à jour des quantités d'alcool
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

            audioSource.PlayOneShot(soundEffect);

            // Mise à jour après préparation
            UpdateBottleQuantityUI();
        }
    }

    private void DistilleryUpdateUI()
    {
        for (int i = 0; i < requiredAmounts.Length; i++)
        {
            if (ingredientTexts[i] != null)
            {
                ingredientTexts[i].text = $"{Inventory.Instance.GetIngredientQuantity(ingredientNames[i])} / {requiredAmounts[i]}";
            }
        }
    }

    private void UpdateBottleQuantityUI()
    {
        int alcoholQuantity = alcoholName switch
        {
            "brandy" => Inventory.Instance.brandyAmount,
            "wiskey" => Inventory.Instance.wiskeyAmount,
            "cognac" => Inventory.Instance.cognacAmount,
            "grandMarnier" => Inventory.Instance.grandMarnierAmount,
            "absinthe" => Inventory.Instance.absintheAmount,
            _ => 0
        };

        if (bottleAmountText != null)
        {
            bottleAmountText.text = $"Owned : {alcoholQuantity}";
        }
    }
}
