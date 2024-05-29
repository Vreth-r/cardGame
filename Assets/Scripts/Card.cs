using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

/*
    Card class: defines what a card is
    Contains:
        - Card information/stats
        - Constructor for making new cards
        - CardType enum
*/

public class Card
{
    // Declare all stat variables to see in the unity inspector
    public int id;
    public string cardName;
    public int cost;
    public int attackPoints;
    public int healthPoints;
    public string description;
    public Sprite artwork;
    public cardNamespace.CardType cardType;

    // Class constructor
    public Card(int Id, string CardName, int Cost, int AttackPoints, int HealthPoints, string Description, cardNamespace.CardType Type)
    {
        this.id = Id;
        this.cardName = CardName;
        this.cost = Cost;
        this.attackPoints = AttackPoints;
        this.healthPoints = HealthPoints;
        this.description = Description;
        this.cardType = Type;
    }
}

namespace cardNamespace
{
    public enum CardType
    {
        Unit,
        Spell
    }
}
