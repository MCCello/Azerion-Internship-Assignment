using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InitializeCards : MonoBehaviour
{
    public List<Card> Deck = new List<Card>();
    private void Start()
    {
        DeckInnit();
    }
    void DeckInnit()
    {
        for (int i = 2; i <= 14; i++)
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                AddCards(i, suit);
            }
        }
    }
    void AddCards(int i, Suit s)
    {
        Deck.Add(new Card(i, s));
    }
    //debugging method for printing all cards in deck.
    public void PrintDeck()
    {
        foreach (Card c in Deck)
        {
            Debug.Log(c.ToString());
        }
    }
}
