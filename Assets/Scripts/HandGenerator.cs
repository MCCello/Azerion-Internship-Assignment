using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandGenerator : MonoBehaviour
{
    public InitializeCards initializeCards;

    private void Start()
    {
        initializeCards = GetComponent<InitializeCards>();
    }
    //Randomizing the number to get element from list makes it possible to have repeated cards as shown in the example
    //additionally it is more efficient as we are referencing the cards in a centralized startup location.
    public List<Card> CreateHand()
    {
        List<Card> thisHand = new List<Card>();

        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, initializeCards.Deck.Count);

            thisHand.Add(initializeCards.Deck.ElementAt(random));

            Debug.Log(thisHand[i].ToString());
        }
        
        return thisHand;
    }
}
