using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    CardManager Script: clones the card prefab and assigns it a card from the database
    (Instantiates each card on startup)
*/
public class CardManager : MonoBehaviour
{    
    public CardDatabase cardDatabase; // Card database reference
    public GameObject cardPrefab; // Card prefab reference
    public Transform cardParent; // Card parent reference

    void Start()
    {
        foreach (Card card in cardDatabase.cards) //  For each card in the database
        {
            GameObject cardObject = Instantiate(cardPrefab, cardParent); // Clone the Card prefab
            CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>(); // grab reference for the display script on the cloned card
            cardDisplay.card = card; // Set it to a card in the DB
        }
    }
}
