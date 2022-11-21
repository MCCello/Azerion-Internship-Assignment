using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Enum of suits for consistency.
public enum Suit
{
    HEARTS,
    DIAMONDS,
    CLUBS,
    SPADES
}

//struct of cards 
public struct Card
{
    public Card(int number, Suit suit)
    {
        Number = number;
        Suit = suit;
    }
    public int Number { get; }
    public Suit Suit { get; }

    //override of ToString to print the card names & suits in a consistent way.9
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
    //nobody likes repeated code amIright
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
        DeckInnit();
    }

    void DeckInnit()
    {
        for (int i = 1; i <= 13; i++)
        {
            AddCards(i, Suit.HEARTS);
            AddCards(i, Suit.DIAMONDS);
            AddCards(i, Suit.CLUBS);
            AddCards(i, Suit.SPADES);
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
