using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        rankings = Rankings.Empty;
        handValidator = FindObjectOfType<HandValidator>();
        handGenerator = FindObjectOfType<HandGenerator>();
        hand = handGenerator.CreateHand();
        //TestHand();
    }

    public void PrintHand()
    {
        foreach (Card item in hand)
        {
            Debug.Log(item.ToString());
        }
    }
    void TestHand()
    {
        //for testing purposes,
        hand = new List<Card>();
        hand.Add(new Card(2, Suit.CLUBS));
        hand.Add(new Card(3, Suit.HEARTS));
        hand.Add(new Card(4, Suit.HEARTS));
        hand.Add(new Card(5, Suit.HEARTS));
        hand.Add(new Card(6, Suit.HEARTS));
    }
    public void CheckHandResult()
    {
        rankings = handValidator.CheckHandResult(hand);
        
    }
}
