using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    CardDisplay Script: Renders a cards stats onto a Card Prefab
    - Takes in a Card and renders its stats
    - Has fields for each text field on the card prefab, should already be assigned in the prefab
    - the start method will change all the TMP fields to the card stats
*/
public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
    public Image artworkImage;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        manaText.text = card.cost.ToString();
        attackText.text = card.attackPoints.ToString();
        healthText.text = card.healthPoints.ToString();
    }
}
