using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedBack : MonoBehaviour
{
    [Header("References"), Space(5)]
    public int amount;
    public string amoutTypeText;
    public TMP_Text feedbackText;
    public Animation feedbackAnimation;
    
    // Start is called before the first frame update
    private void Start()
    {
        UpdateFeedBackUI();
    }

    // Update is called once per frame
    void UpdateFeedBackUI()
    {
        if (feedbackText != null)
        {
            feedbackText.text = "+ " + amount.ToString()+ " " + amoutTypeText.ToString();
        }
    }   
}
