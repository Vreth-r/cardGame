/*
    Author: Michael Latka
    ********************
    CardEffects Class:
    ********************

    Defines what card effects are

	A CardEffect is is a duo of a trigger event and an effect to go along with it

	An Effect is a specific action ran upon a trigger event. Each Effect can be modified to do certain actions by inheriting the Effect class and overriding its methods

	An Effect has an Owner player and an Opponent player, as well as a card owner and target.

	NOTE: Might merge this into CardMechanics
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The abstract general Effect class (all effects inherit this class)
public abstract class Effect
{
    public Player owner;
    public Player opp;
    public abstract void Apply();
}

public enum CardEvent
{
    OnDraw,
    OnPlay,
    OnDiscard,
    OnActivate,
    None
}

// The CardEffect class that couples an Effect with it's trigger event
// Done this way because there would have to be multiple instances of the same effect for different activiations, this way, 
// there is only one class that handles assigning the trigger event for a general effect instance. 
[System.Serializable]
public class CardEffect
{
    public CardEvent triggerEvent;
    public Effect effect;
    public Player owner;
    public Player opp;

    // Instantiate
    public CardEffect(Effect effect, CardEvent triggerEvent)
    {
        this.triggerEvent = triggerEvent;
        this.effect = effect;
    }

    public void SetTargets(Player owner, Player opp)
    {
        this.owner = owner;
        this.opp = opp;

        effect.owner = owner;
        effect.opp = opp;
    }
}

// The effect that allows players to draw N number of cards
public class DrawCard : Effect
{
    public int cardsToDraw;

    public DrawCard(int cardsToDraw)
    {
        this.cardsToDraw = cardsToDraw;
    }

    public override void Apply()
    {
        for (int i = 0; i < this.cardsToDraw; i++)
        {
            owner.Draw();
        }
    }
}

// There can be more effects defined here
