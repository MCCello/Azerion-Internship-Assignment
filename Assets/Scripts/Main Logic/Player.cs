using System;
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

    //testing purposes
    public List<int> handInts;
    private void Start()
    {
        rankings = Rankings.Empty;
        handValidator = FindObjectOfType<HandValidator>();
        handGenerator = FindObjectOfType<HandGenerator>();
        //hand = handGenerator.CreateHand();
        TestHand();
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
        hand = new List<Card>();

        foreach (int i in handInts)
        {
            Array enums = Enum.GetValues(typeof(Suit));
            int random = UnityEngine.Random.Range(0, enums.Length);
            hand.Add(new Card(i, Suit.CLUBS));
            //(Suit)enums.GetValue(random)
        }
        //for testing purposes,

    }
    public void CheckHandResult()
    {
        rankings = handValidator.CheckHandResult(hand);
        
    }
}
