using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum Suit
{
    HEARTS,
    DIAMONDS,
    CLUBS,
    SPADES
}
public struct Card
{
    public Card(int number, Suit suit)
    {
        Number = number;
        Suit = suit;
    }

    public int Number { get; }
    public Suit Suit { get; }

    public override string ToString()
    {
        //not the most efficient route - clean up!!
        if (Number == 1)
        {
            return RepeatedCode("Ace", Suit);
        }
        if (Number == 11)
        {
            return RepeatedCode("Jack", Suit);
        }
        if (Number == 12)
        {
            return RepeatedCode("Queen", Suit);
        }
        if (Number == 13)
        {
            return RepeatedCode("King", Suit);
        }
        return RepeatedCode(Number.ToString(), Suit);
    }
    string RepeatedCode(string number, Suit suit)
    {
        return $"Card No. {number} of {suit}";
    }
}
public class InitializeCards : MonoBehaviour
{
    public List<Card> Deck = new List<Card>();

    private void Start()
    {
        for (int i = 1; i <= 13; i++)
        {
            Deck.Add(new Card(i, Suit.HEARTS)); // repeated code clean up!!
            Deck.Add(new Card(i, Suit.DIAMONDS));
            Deck.Add(new Card(i, Suit.CLUBS));
            Deck.Add(new Card(i, Suit.SPADES));
        }
    }

    public void PrintDeck()
    {
        foreach (Card c in Deck)
        {
            Debug.Log(c.ToString());
        }
    }
}
