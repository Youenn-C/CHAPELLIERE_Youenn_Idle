using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [Header("Drake"), Space(5)]
    public int richness = 0;
    
    [Header("Ingredients"), Space(5)]
    public int appleAmount;
    public int cherryAmount;
    public int pearAmount;
    public int cerealsAmount;
    public int waterAmount;
    public int yeastAmount;
    public int whiteGrapesAmount;
    public int exoticOrangeEssenceAmount;
    public int fennelAmount;
    public int lemonBalmAmount;
    public int hyssopAmount;

    [Header("Alcohol"), Space(5)]
    public int brandyAmount;
    public int wiskeyAmount;
    public int cognacAmount;
    public int grandMarnierAmount;
    public int absintheAmount;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public int GetIngredientQuantity(string ingredientName)
    {
        switch (ingredientName)
        {
            case "apple":
                return appleAmount;
            case "cherry":
                return cherryAmount;
            case "pear":
                return pearAmount;
            case "cereals":
                return cerealsAmount;
            case "water":
                return waterAmount;
            case "yeast":
                return yeastAmount;
            case "whiteGrapes":
                return whiteGrapesAmount;
            case "exoticOrangeEssence":
                return exoticOrangeEssenceAmount;
            case "fennel":
                return fennelAmount;
            case "lemonBalm":
                return lemonBalmAmount;
            case "hyssop":
                return hyssopAmount;
            default:
                Debug.LogWarning("Ingrédient inconnu: " + ingredientName);
                return 0; // Retourne 0 si l'ingrédient n'est pas trouvé
        }
    }
    
    public void IncrementIngredient(string ingredientName)
    {
        switch (ingredientName)
        {
            case "apple":
                appleAmount++;
                break;
            case "cherry":
                cherryAmount++;
                break;
            case "pear":
                pearAmount++;
                break;
            case "cereals":
                cerealsAmount++;
                break;
            case "water":
                waterAmount++;
                break;
            case "yeast":
                yeastAmount++;
                break;
            case "whiteGrapes":
                whiteGrapesAmount++;
                break;
            case "exoticOrangeEssence":
                exoticOrangeEssenceAmount++;
                break;
            case "fennel":
                fennelAmount++;
                break;
            case "lemonBalm":
                lemonBalmAmount++;
                break;
            case "hyssop":
                hyssopAmount++;
                break;
            default:
                Debug.LogWarning("Ingrédient inconnu: " + ingredientName);
                break;
        }
    }
    
    public void DecrementIngredient(string ingredientName, int amount)
    {
        switch (ingredientName)
        {
            case "apple":
                appleAmount -= amount;
                break;
            case "cherry":
                cherryAmount -= amount;
                break;
            case "pear":
                pearAmount -= amount;
                break;
            case "cereals":
                cerealsAmount -= amount;
                break;
            case "water":
                waterAmount -= amount;
                break;
            case "yeast":
                yeastAmount -= amount;
                break;
            case "whiteGrapes":
                whiteGrapesAmount -= amount;
                break;
            case "exoticOrangeEssence":
                exoticOrangeEssenceAmount -= amount;
                break;
            case "fennel":
                fennelAmount -= amount;
                break;
            case "lemonBalm":
                lemonBalmAmount -= amount;
                break;
            case "hyssop":
                hyssopAmount -= amount;
                break;
            default:
                Debug.LogWarning("Ingrédient inconnu: " + ingredientName);
                break;
        }
    }

}
