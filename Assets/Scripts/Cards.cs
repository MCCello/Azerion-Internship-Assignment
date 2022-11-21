using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
