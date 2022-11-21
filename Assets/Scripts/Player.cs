using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    HandGenerator handGenerator;
    [SerializeField]
    HandValidator handValidator;

    public List<Card> hand;
    public Rankings rankings;

    private void Start()
    {
        handValidator = FindObjectOfType<HandValidator>();
        handGenerator = FindObjectOfType<HandGenerator>();
        //hand = handGenerator.CreateHand();

        //for testing purposes, ^^ above line for randomized hand
        hand = new List<Card>();
        hand.Add(new Card(1, Suit.HEARTS));
        hand.Add(new Card(1, Suit.DIAMONDS));
        hand.Add(new Card(1, Suit.CLUBS));
        hand.Add(new Card(2, Suit.DIAMONDS));
        hand.Add(new Card(2, Suit.HEARTS));
    }

    public void PrintHand()
    {
        foreach (Card item in hand)
        {
            Debug.Log(item.ToString());
        }
    }
    public void CheckHandResult()
    {
        rankings = handValidator.CheckHandResult(hand);
        
    }
}
