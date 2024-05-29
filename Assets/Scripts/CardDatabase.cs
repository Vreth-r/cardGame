using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cardNamespace;
[CreateAssetMenu(fileName = "New Card Database", menuName = "Card Database")]

/*
    CardDatabase Script: Keeps a record of all cards 
*/
public class CardDatabase : ScriptableObject
{
    public List<Card> cards;

    void Awake()
    {
        cards = new List<Card>();
        cards.Add(new Card(1, "Jahseh", 10, 1, 2, "The only.", cardNamespace.CardType.Unit));
        cards.Add(new Card(2, "Geykume", 5, 2, 9, "The child.", cardNamespace.CardType.Unit));
    }
}
