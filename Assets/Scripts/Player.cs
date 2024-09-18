/*
    Author: Michael Latka
    ********************
    Player Script:
    ********************

    Stores the player information like where all their cards are, player stats, and defines actions like drawing cards and playing them. 

    NOTE: currently, the player is the class that actually moves the cards around, but I might add extra methods to the card mechanics class that also support card actions
          like drawing cards just so theres more readability between classes, also for proper coding practice.

    Note: Might change the MoveCardToZone method to move the card's between the zone lists as well instead of just setting position and other flags related, for comphrehension
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StaticBoardZone hand;
    public StaticBoardZone deck;
    public DynamicBoardZone units;
    public StaticBoardZone discard;
    public StaticBoardZone exile;
    public StaticBoardZone prismatic;
    public DynamicBoardZone combat;
    public int mana;
    public int health;
    public bool isLocal;
    public bool hasEndedMainPhase;
    public bool hasEndedStartup;
    public bool hasEndedCombatPhase;

    // Draw a card if deck is not empty
    public void Draw()
    {
        // TODO: tweak this for multiple card draws later
        GameObject drawnCard = deck.GetFromTop(); // Pop the card on top of the deck
        CardMechanics script = drawnCard.GetComponent<CardMechanics>();
        script.FlipCard();
        script.TriggerEvent(CardEvent.OnDraw); // Trigger the on card draw event
        hand.InsertCard(drawnCard);
    }

    // Takes damage if possible
    public void TakeDamage(int amount)
    {
        if(health - amount <= 0)
        {
            health = 0;
            // add code to end game here
        } else
        {
            health -= amount;
        }
    }

    // Ends turn if possible
    public void EndTurn()
    {
        return;
    }

    // Initializes the player fields
    public void Initialize(bool local, List<Vector3> coords)
    {
        isLocal = local; // Sets whether this player is local to the machine or not (decided by the game manager)

        deck = new StaticBoardZone(coords[0], false, false);
        units = new DynamicBoardZone(coords.GetRange(1,5).ToArray(), 5);
        discard = new StaticBoardZone(coords[6], false, true);
        exile = new StaticBoardZone(coords[7], false, true);
        prismatic = new StaticBoardZone(coords[8], false, true);
        combat = new DynamicBoardZone(new Vector3[]{coords[9]}, 5);
        hand = new StaticBoardZone(coords[10], true, true);

        health = 20;
        mana = 1;
        hasEndedMainPhase = false;
        hasEndedStartup = false;

    }
}

// Stacks of cards (deck, discard, hand, etc)
public class StaticBoardZone
{
    private Vector3 position;
    private List<GameObject> cards;
    private bool spread; // when the card group acts as a stack but all have to be physically seen (like in the hand)
    private bool visable;

    public StaticBoardZone(Vector3 position, bool spread, bool visable)
    {
        this.position = position;
        this.spread = spread;
        this.visable = visable;
        this.cards = new List<GameObject>();
    }

    public void InsertCard(GameObject card)
    {
        cards.Add(card);
        CardMechanics script = card.GetComponent<CardMechanics>();

        if(spread)
        {
            if(cards.Count == 1)
            {
                card.transform.position = position;
            } else 
            {
                card.transform.position = position + new Vector3(cards.Count, 0, 0);
            }
            script.dragable = true;
        } else 
        {
            card.transform.position = position;
            script.dragable = false;
        }

        if ((visable && script.flip) || (!visable && !script.flip)) 
        {
            script.FlipCard(); // Flip the card if the zone is visible and the card is face down, or if the zone is not visible and the card is face up
        }
    }

    public void RemoveCard(GameObject card)
    {
        cards.Remove(card);
    }

    public GameObject GetFromTop()
    {
        GameObject cardR = cards[0];
        cards.RemoveAt(0);
        return cardR;
    }
}

// Cards in specific spots in a zone (unit zone, combat zone, etc)
public class DynamicBoardZone
{
    private Vector3[] positions;
    private int slots;
    private GameObject[] cards;

    public DynamicBoardZone(Vector3[] positions, int slots)
    {
        this.positions = positions;
        this.slots = slots;
        this.cards = new GameObject[slots];
    }

    public void InsertCard(GameObject card, int slot)
    {
        if(slot >= 0 && slot <= slots && cards[slot] == null) // if the slot is valid and not taken by something
        {
            cards[slot] = card;
            card.transform.position = positions[slot];
        }
    }

    public void RemoveCard(GameObject card)
    {
        for(int i = 0; i < cards.Length; i++)
        {
            if(cards[i] == card)
            {
                cards[i] = null;
            }
        }
    }
}
