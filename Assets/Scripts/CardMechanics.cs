/*
    Author: Michael Latka
    ********************
    Card Mechanics Script:
    ********************

    Copies all the card data for it's respective card into itself and acts as the live tracker for its stats.

    Handles card physics and click actions.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]

public class CardMechanics : MonoBehaviour 
{
    // Mechanics properties
    private Vector3 screenPoint;
    private Vector3 offset;
    private float zcoord;
    public Vector3 currentPos = new Vector3();
    private GameObject uiViewer;
    private UIViewer uiScript;
    public Coordinates coords;
    public CardDisplay display;
    public GameObject menuInstance;

    // Card properties
    public int id;
    public string cardName;
    public int cost;
    public int attackPoints;
    public int healthPoints;
    public string description;
    public cardNamespace.CardType type;
    public cardNamespace.CardElement element;
    public cardNamespace.CardTag cardTag;
    public cardNamespace.CardRarity rarity;
    public string zone;
    public Color color;
    public Sprite artwork;
    public bool flip; // true when face down, false when face up
    public bool dragable;
    public List<CardEffect> effects;
    public Player owner;
    public Player opp;

    public void Initialize(Card card, CardDisplay cardDisplay, GameObject UiViewer, Coordinates Coords)
    {
        id = card.id;
        cardName = card.name;
        cost = card.cost;
        attackPoints = card.attackPoints;
        healthPoints = card.healthPoints;
        description = card.description;
        type = card.type;
        element = card.element;
        cardTag = card.tag;
        rarity = card.rarity;
        zone = card.zone;
        color = card.getColor();
        artwork = card.artwork;
        flip = card.flip;
        dragable = card.dragable;
        effects = card.effects;
        if (effects != null)
        {
            foreach (CardEffect cardEffect in effects)
            {
                cardEffect.SetTargets(owner, opp);
            }
        }

        uiViewer = UiViewer;
        uiScript = uiViewer.GetComponent<UIViewer>(); // Grabs UI viewer script reference on startup
        uiScript.card = this;
        display = cardDisplay;
        display.card = this;
        coords = Coords;
    }

    // Triggers all effects for the provided event
    public void TriggerEvent(CardEvent cardEvent)
    {
        if (effects != null)
        {
            foreach (CardEffect cardEffect in effects)
            {
                if (cardEffect.effect != null && cardEffect.triggerEvent == cardEvent)
                {
                    cardEffect.effect.Apply();
                }
            }
        }
    }

    public void FlipCard()
    {
        if(flip) // if face down
        {
            gameObject.transform.Rotate(0,0,0);
            flip = false;
        } else {
            gameObject.transform.Rotate(0,180,0);
            flip = true;
        }
    }

    
    public void SendToViewer()
    {  
        // Send card info to UI Viewer
        if(!flip) // if face up
        {
            uiScript.card = this;
            uiViewer.SetActive(true);
        } else 
        {
            uiViewer.SetActive(false);
        }
    } 

}
