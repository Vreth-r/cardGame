/*
    Author: Michael Latka
    ********************
    Game Manager Script:
    ********************

    Manages the game flow with tools like game states and coroutines.

    Initializes everything then begins the game loop. Tells things what to do and when to do it.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public Camera mainCamera;
    public CardDatabase cardLib; // Card database reference
    public GameObject cardPrefab; // Card prefab reference
    public GameObject menuInstance; // Menu reference
    public Transform cardParent; // Card parent reference
    public Transform canvasParent; // Camera Canvas parent (where the UI viewer is rendered)
    public GameObject uiViewer; // Card UI viewer reference
    public Coordinates coords; // Coordinate database reference
    public Player localPlayer; // Local player reference
    public Player opPlayer; // Opponent player reference
    private Player currentPlayer; // The current players turn
    public int turn = 1; // The turn number
    public GameState currentState; // The current state of the game

    // Ran before first frame
    void Start()
    {
        coords.Initialize(); // Initalize the coordinate dict
        uiViewer.SetActive(false); // Start the uiViewer as inactive
        localPlayer.Initialize(true, coords.GetPlayerCoords(1)); // Initialize players and give them their coords (so they know where to place cards)
        opPlayer.Initialize(false, coords.GetPlayerCoords(2));
        cardLib.Initialize();

        foreach (Card cardData in cardLib.cards) //  For each card in the database (this will change to a list of cards to be instantiated during a specific match)
        {
            GameObject cardObject = Instantiate(cardPrefab, cardParent); // Clone the Card prefab
            CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>(); // Grab reference for the display script on the cloned card
            CardMechanics cardMechanics = cardObject.GetComponent<CardMechanics>(); // Grab reference for the mechanics script

            if(cardData.player == 1) // If card belongs to player 1 (Temporary system)
            {
                localPlayer.deck.InsertCard(cardObject); // Add to "player 1"'s deck
                cardMechanics.owner = localPlayer; // Set the mechanics owner player to the local player
                cardMechanics.opp = opPlayer; // Set the mechanics opponent player to the opponent player
            } else 
            {
                cardObject.transform.Rotate(0,0,180); // Otherwise, turn the cards around to face the other direction
                opPlayer.deck.InsertCard(cardObject); // Do the same but for the opponent player
                cardMechanics.owner = opPlayer;
                cardMechanics.opp = localPlayer;
            }
            cardMechanics.Initialize(cardData, cardDisplay, uiViewer, coords); // Initialize the card mechanics script
            cardMechanics.FlipCard(); // Flip the card over cause its starting in the deck
        }
        currentPlayer = localPlayer; // set current player, will change later when networking is introduced  

        // Start the coroutine game loop
        StartCoroutine(GameLoop());
    } 

    // Click Handling
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleClick(0); // Handle a left click
        }
        else if(Input.GetMouseButtonDown(1))
        {
            HandleClick(1); // Handle a right click
        }
    }

    private void HandleClick(int mouseButton)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.collider.gameObject;

            // Left click
            if(mouseButton == 0)
            {
                // Check if the clicked object has the tag 'Card'
                if (clickedObject.CompareTag("Card"))
                {
                    clickedObject.GetComponent<CardMechanics>().SendToViewer();
                }
                else
                {
                    uiViewer.SetActive(false);
                }
            }
            else if(mouseButton == 1)
            {
                // right click functions (like popup menu)
            }
        }
    }

    // Master game loop method
    IEnumerator GameLoop()
    {
        while (currentState != GameState.GameEnd) // While the game hasn't ended yet
        {
            switch (currentState)
            {
                case GameState.Setup: // If the current phase is the setup phase
                    yield return StartCoroutine(SetupPhase()); // Go to the setup phase
                    break;
                case GameState.Main: // If the current phase is the main phase
                    yield return StartCoroutine(MainPhase()); // Go to the main phase
                    break;
                case GameState.Combat: // If the current phase is the combat phase
                    yield return StartCoroutine(CombatPhase()); // Go to the combat phase
                    break;
                case GameState.End: // If the current phase is the end phase
                    yield return StartCoroutine(EndPhase()); // Go to the end phase
                    break;
            }
        }
    }

    // Setup phase function
    IEnumerator SetupPhase()
    {
        // Both players draw a card and are allowed to play one non spell card
        // Card effects cannot target the other players cards
        // once all effects are resolved, automatically go to the main phase
        localPlayer.Draw();
        opPlayer.Draw();
        currentState = GameState.Main;
        yield break;
    }

    // Everything from here is not done yet *******
    IEnumerator MainPhase()
    {
        // Wait for player to end their main phase
        while (!currentPlayer.hasEndedMainPhase)
        {
            yield return null; // Wait for next frame
        }
        currentState = GameState.Combat;
    }

    IEnumerator CombatPhase()
    {
        // Wait for player to end their attack phase
        while (!currentPlayer.hasEndedCombatPhase)
        {
            yield return null; // Wait for next frame
        }
        currentState = GameState.End;
    }

    IEnumerator EndPhase()
    {
        // Resolve end-of-turn effects
        currentPlayer.EndTurn();
        // Switch to the other player
        currentPlayer = (currentPlayer == localPlayer) ? opPlayer : localPlayer;
        currentState = GameState.Setup;
        yield break;
    }

    public enum GameState
    {
        Setup,
        Main,
        Combat,
        End,
        GameEnd
    }
    
}