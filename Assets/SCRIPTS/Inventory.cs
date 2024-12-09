using System.Collections;
using System.Collections.Generic;
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
}
