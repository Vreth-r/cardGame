/*
    Author: Michael Latka
    ********************
    UI Viewer Script:
    ********************

    Grabs all relevant data from the CardMechanics Script and constantly updates each card rendering.

    It is enabled and disabled throughout the other scripts as needed

    NOTE: Will change this to update on event later
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
    UIViewer Script: Renders a cards stats in the card viewer
*/
public class UIViewer : MonoBehaviour
{
    public CardMechanics card;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI nameTextCard;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI descriptionTextCard;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI manaTextCard;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI attackTextCard;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthTextCard;
    public TextMeshProUGUI tagText;
    public TextMeshProUGUI tagTextCard;
    public TextMeshProUGUI elementText;
    public TextMeshProUGUI elementTextCard;
    public TextMeshProUGUI rarityText;
    public TextMeshProUGUI rarityTextCard;
    public Image colorCard;

    void Update()
    {
        // Set UI text
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        manaText.text = card.cost.ToString();
        attackText.text = card.attackPoints.ToString();
        healthText.text = card.healthPoints.ToString();
        tagText.text = card.cardTag.ToString();
        elementText.text = card.element.ToString();
        rarityText.text = card.rarity.ToString();

        // Set the display card
        nameTextCard.text = card.cardName;
        descriptionTextCard.text = card.description;
        manaTextCard.text = card.cost.ToString();
        attackTextCard.text = card.attackPoints.ToString();
        healthTextCard.text = card.healthPoints.ToString();
        tagTextCard.text = card.cardTag.ToString();
        elementTextCard.text = card.element.ToString();
        colorCard.color = card.color;
        // No rarity yet in the display script
    }
}
