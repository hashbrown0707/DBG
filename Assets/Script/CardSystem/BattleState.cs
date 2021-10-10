using System;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;
using System.Collections;

public class BattleState : MonoBehaviour
{
    public PlayerData playerData;

    private Hand hand;
    private Piles piles;
    private Deck deck;

    public void Awake()
    {
        hand = FindObjectOfType<Hand>();
        piles = new Piles();
        deck = new Deck();

        deck.InitDeck(playerData.deckData);
    }

    public void StartBattle()
    {
        piles.InitAllPiles(deck);
        StartTurn();
    }

    public void StartTurn()
    {
        Debug.Log("Start Turn");

        hand.DrawCards(5);

    }

    public void EndTurn()
    {
        StartCoroutine(EndTurnCoroutine());
    }

    private IEnumerator EndTurnCoroutine()
    {
        hand.DiscardAllCard();
        yield return new WaitForSeconds(.5f);
        StartTurn();
        yield break;
    }

}
