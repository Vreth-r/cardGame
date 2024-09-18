/*
    Author: Michael Latka
    ********************
    Card Class:
    ********************

    Defines what a card is for stats and fields. All of this information is copied over to the card mechanics class. 
    The information stored in each instance of this class is "golden" and not to be modified live as it is an original value reference.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Card
{
    // Declare all stat variables to see in the unity inspector
    public int id;
    public string name;
    public int cost;
    public int attackPoints;
    public int healthPoints;
    public string description;
    public cardNamespace.CardType type;
    public cardNamespace.CardElement element;
    public cardNamespace.CardTag tag;
    public cardNamespace.CardRarity rarity;
    public string zone;
    private Color color;
    public Sprite artwork;
    public bool flip; // true when face down, false when face up
    public bool dragable;
    public List<CardEffect> effects;

    public int player; // UNTIL THE DECKBUILDING AND MULTIPLAYER IS DONE, CARDS WILL HAVE PLAYERS ASSIGNED TO THEM MANUALLY THROUGH THE CONSTRUCTOR


    // Class constructor (Need to add artwork here once the system is set up)
    public Card(int Id, string Name, int Cost, int AttackPoints, 
    int HealthPoints, string Description, cardNamespace.CardType Type,
    cardNamespace.CardElement Element, cardNamespace.CardTag Tag, cardNamespace.CardRarity Rarity, int Player, List<CardEffect> Effects)
    {
        this.id = Id;
        this.name = Name;
        this.cost = Cost;
        this.attackPoints = AttackPoints;
        this.healthPoints = HealthPoints;
        this.description = Description;
        this.type = Type;
        this.element = Element;
        this.tag = Tag;
        this.rarity = Rarity;
        this.zone = "none";
        this.flip = true;
        this.dragable = false;
        this.effects = Effects;

        this.player = Player; // to be removed
        // TODO: set border color based off rarity akin to element

        // Set color according to element
        switch(Element) 
        {
        case cardNamespace.CardElement.Fire:
            this.color = new Color(1.0f, 0.39f, 0.38f);
            break;
        case cardNamespace.CardElement.Water:
            this.color = new Color(0.24f, 0.5f, 1.0f);
            break;
        case cardNamespace.CardElement.Earth:
            this.color = new Color(0.27f, 0.11f, 0.04f);
            break;
        case cardNamespace.CardElement.Air:
            this.color = new Color(0.43f, 1.0f, 0.63f);
            break;
        case cardNamespace.CardElement.Lightning:
            this.color = new Color(0.74f, 0.43f, 1.0f);
            break;
        case cardNamespace.CardElement.Light:
            this.color = new Color(0.94f, 0.94f, 0.86f);
            break;
        case cardNamespace.CardElement.Dark:
            this.color = new Color(0.23f, 0.23f, 0.23f);
            break;
        default:
            this.color = new Color(0.74f, 0.74f, 0.74f);
            break;
        }
    }

    public Color getColor()
    {
        return this.color;
    }
}

// Will rewrite this to be apart of the actual class later, did this because i was figuring out some c# stuff.
namespace cardNamespace
{
    public enum CardType
    {
        Unit,
        Spell
    }

    public enum CardTag
    {
        // gonna be more later
        Monster,
        Machine,
        Arcane,
        None
    }

    public enum CardElement
    {
        Fire,
        Water,
        Earth,
        Air,
        Lightning,
        Light,
        Dark,
        None
    }

    public enum CardRarity
    {
        Normal,
        Rare,
        Epic,
        Legendary,
        Prismatic
    }
}
