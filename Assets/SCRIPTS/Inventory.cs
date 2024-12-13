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
    public int largeWormwoodAmount;
    public int smallWormwoodAmount;
    public int greenAniseAmount;
    public int fennelAmount;
    public int lemonBalmAmount;
    public int hyssopAmount;

    [Header("Alcohol"), Space(5)]
    public int brandyAmount;
    public int wiskeyAmount;
    public int cognacAmount;
    public int GrandMarnierAmount;
    public int absintheAmount;
    
    private void Awake()
    {
        // Singleton pour assurer qu'il n'y a qu'une seule instance de ScoreManager
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
            case "largeWormwood":
                return largeWormwoodAmount;
            case "smallWormwood":
                return smallWormwoodAmount;
            case "greenAnise":
                return greenAniseAmount;
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
            case "largeWormwood":
                largeWormwoodAmount++;
                break;
            case "smallWormwood":
                smallWormwoodAmount++;
                break;
            case "greenAnise":
                greenAniseAmount++;
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
}
