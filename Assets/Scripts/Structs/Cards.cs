using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//Enum of suits for consistency.
public enum Suit
{
    HEARTS = 0,
    DIAMONDS = 1,
    CLUBS = 2,
    SPADES = 3
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
        return $"Card No. {Number.ToString().Replace("11", "J").Replace("12", "Q").Replace("13", "K").Replace("14", "A")} of {Suit}";
    }
}
public enum Rankings { RoyalFlush, StraightFlush, FourOfAKind, FullHouse, Flush, Straight, ThreeOfAKind, TwoPair, OnePair, HighCard, Empty }

