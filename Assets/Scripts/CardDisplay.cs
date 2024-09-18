/*
    Author: Michael Latka
    ********************
    Card Display Script:
    ********************

    Grabs all relevant data from the CardMechanics Script and continualisouly updates each card rendering.

    NOTE: Will change this to update on event later
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardMechanics card;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI tagText;
    public TextMeshProUGUI elementText;
    public Image cardColor;
    public Image artworkImage;

    // Start is called before the first frame update
    void Update()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        manaText.text = card.cost.ToString();
        attackText.text = card.attackPoints.ToString();
        healthText.text = card.healthPoints.ToString();
        tagText.text = card.cardTag.ToString();
        elementText.text = card.element.ToString();
        cardColor.color = card.color;
    }
}
