/*
    Author: Michael Latka
    ********************
    Card Database Scriptable Object:
    ********************

    Stores all the cards with their information according to the card class
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cardNamespace;
[CreateAssetMenu(fileName = "CardDB", menuName = "Card Game/NewCardDB")]

public class CardDatabase : ScriptableObject
{
    public List<Card> cards;

    public void Initialize()
    {
        cards = new List<Card>();
        cards.Add(new Card(1, "Ifrit", 2, 1, 3, "When this card is drawn, draw a card.",
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Fire, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        new List<CardEffect>
        {
            new CardEffect(new DrawCard(1), CardEvent.OnDraw)
        }
        ));
        cards.Add(new Card(2, "Hydaelyn", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Light, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        null));
        cards.Add(new Card(3, "Zodiark", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Dark, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        null));
        cards.Add(new Card(4, "Leviathan", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Water, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        null));
        cards.Add(new Card(5, "Titan", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Earth, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        null));
        cards.Add(new Card(6, "Garuda", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Air, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        null));
        cards.Add(new Card(7, "Ramuh", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Lightning, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        1,
        null));
        cards.Add(new Card(8, "Kirin", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Lightning, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        2,
        null));
        cards.Add(new Card(9, "Kulve Taroth", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Earth, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        2,
        null));
        cards.Add(new Card(10, "Kushala Daora", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Air, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        2,
        null));
        cards.Add(new Card(11, "Teostra", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Fire, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        2,
        null));
        cards.Add(new Card(12, "Vaal Hazak", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Dark, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        2,
        null));
        cards.Add(new Card(13, "Alatreon", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.None, 
        cardNamespace.CardTag.Arcane,
        cardNamespace.CardRarity.Epic,
        2,
        null));
        cards.Add(new Card(14, "Shara Ishvalda", 1, 1, 1, "Desc", 
        cardNamespace.CardType.Unit, 
        cardNamespace.CardElement.Earth, 
        cardNamespace.CardTag.None,
        cardNamespace.CardRarity.Epic,
        2,
        null));
    }
}
