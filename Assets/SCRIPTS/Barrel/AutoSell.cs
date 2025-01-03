using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoSell : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string alcoholName; // Nom de l'alcool à vendre
    [SerializeField] private float maxTime; // Temps maximum en secondes

    [Header("UI")]
    [SerializeField] private Image filledImage; // Image avec remplissage
    [SerializeField] private TMP_Text bottleCountText; // Texte affichant la quantité de bouteilles

    private float currentTime = 0f; // Temps actuel
    private bool isAutoSellActive = true; // Indique si la vente automatique est active

    private void Start()
    {
        SetFullFilledImage(); // Initialise l'image comme pleine
        UpdateBottleCount(); // Met à jour l'affichage de la quantité
    }

    private void Update()
    {
        UpdateBottleCount(); // Met à jour la quantité de bouteilles à chaque frame

        if (!HasBottlesAvailable())
        {
            if (isAutoSellActive)
            {
                StopAutoSell(); // Arrête la vente automatique et remplit l'image
            }
            return;
        }

        isAutoSellActive = true; // Réactive la vente si des bouteilles sont disponibles

        if (currentTime <= maxTime)
        {
            currentTime += Time.deltaTime; // Incrémente le temps
            UpdateFilledImage(currentTime / maxTime);
        }
        else
        {
            ResetTimer();
            SellAlcohol();
        }
    }

    private void UpdateFilledImage(float fillAmount)
    {
        if (filledImage != null)
        {
            // Met à jour le remplissage
            filledImage.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }

    private void UpdateBottleCount()
    {
        if (bottleCountText != null)
        {
            int currentBottleCount = GetBottleCount();
            bottleCountText.text = $"{currentBottleCount} bottles";
        }
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateFilledImage(0f); // Réinitialise l'image vide
    }

    private void SellAlcohol()
    {
        if (Inventory.Instance != null && GameManager.Instance != null)
        {
            int bottlePrice = 0;

            // Vérifie si l'alcool spécifié existe dans l'inventaire
            switch (alcoholName.ToLower())
            {
                case "brandy":
                    if (Inventory.Instance.brandyAmount > 0)
                    {
                        Inventory.Instance.brandyAmount--;
                        bottlePrice = Inventory.Instance._brandyBottlePrice;
                    }
                    break;
                case "whiskey":
                    if (Inventory.Instance.wiskeyAmount > 0)
                    {
                        Inventory.Instance.wiskeyAmount--;
                        bottlePrice = Inventory.Instance._wiskeyBottlePrice;
                    }
                    break;
                case "cognac":
                    if (Inventory.Instance.cognacAmount > 0)
                    {
                        Inventory.Instance.cognacAmount--;
                        bottlePrice = Inventory.Instance._cognacBottlePrice;
                    }
                    break;
                case "grandmarnier":
                    if (Inventory.Instance.grandMarnierAmount > 0)
                    {
                        Inventory.Instance.grandMarnierAmount--;
                        bottlePrice = Inventory.Instance._grandMarnierBottlePrice;
                    }
                    break;
                case "absinthe":
                    if (Inventory.Instance.absintheAmount > 0)
                    {
                        Inventory.Instance.absintheAmount--;
                        bottlePrice = Inventory.Instance._absintheBottlePrice;
                    }
                    break;
                default:
                    Debug.LogWarning($"Unknown alcohol: {alcoholName}");
                    break;
            }

            // Ajoute les Drakes correspondants
            if (bottlePrice > 0)
            {
                GameManager.Instance.drakeManager.AddDrake(bottlePrice);
            }
        }
    }

    private int GetBottleCount()
    {
        return alcoholName.ToLower() switch
        {
            "brandy" => Inventory.Instance.brandyAmount,
            "wiskey" => Inventory.Instance.wiskeyAmount,
            "cognac" => Inventory.Instance.cognacAmount,
            "grandMarnier" => Inventory.Instance.grandMarnierAmount,
            "absinthe" => Inventory.Instance.absintheAmount,
            _ => 0 // Aucun alcool correspondant trouvé
        };
    }

    private bool HasBottlesAvailable()
    {
        return GetBottleCount() > 0;
    }

    private void StopAutoSell()
    {
        isAutoSellActive = false; // Désactive la vente automatique
        SetFullFilledImage(); // Remplit l'image
    }

    private void SetFullFilledImage()
    {
        if (filledImage != null)
        {
            filledImage.fillAmount = 1f; // Définit l'image comme pleine
        }
    }
}
