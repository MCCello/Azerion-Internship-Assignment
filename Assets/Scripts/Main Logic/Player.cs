using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [Header("Test Variables Ignore")]
    public List<int> handInts;
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
        //for testing purposes, go to editor and edit list of int's inside player gameobjects, then hand will spawn based on that list
        //if you want to test a flush then change line 47

        hand = new List<Card>();

        foreach (int i in handInts)
        {
            Array enums = Enum.GetValues(typeof(Suit));
            int random = UnityEngine.Random.Range(0, enums.Length);
            hand.Add(new Card(i, (Suit)enums.GetValue(random)));
        }
    }
    public void CheckHandResult()
    {
        rankings = handValidator.CheckHandResult(hand);
    }
    public void SortHand()
    {
        hand = hand.OrderByDescending(x => x.Number).ToList();
    }
}
