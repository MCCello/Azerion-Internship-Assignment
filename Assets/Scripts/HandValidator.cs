using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;


public class HandValidator : MonoBehaviour
{
    public List<Card> hand;

    public Rankings CheckHandResult(List<Card> hand_)
    {
        hand = hand_;

        if (CheckFlush().Item1) return CheckFlush().Item2;
        if (CheckThreeOfAKind().Item1) return CheckThreeOfAKind().Item2;
        if (ChecKTwoPair().Item1) return ChecKTwoPair().Item2;
        if (CheckOnePair().Item1) return CheckOnePair().Item2;

        return Rankings.HighCard;
    }

    (bool, Rankings) CheckFullHouse()
    {
        var flush = hand.GroupBy(x => x.Suit).Where(x => x.Count() >= 5).SelectMany(x => x.OrderByDescending(y => y.Number).Take(5));
        return flush.Any() ? (true, Rankings.Flush) : (false, Rankings.Empty);
    }

    (bool, Rankings) CheckFlush()
    {
        var flush = hand.GroupBy(x => x.Suit).Where(x => x.Count() >= 5).SelectMany(x => x.OrderByDescending(y => y.Number).Take(5));
        return flush.Any() ? (true, Rankings.Flush) : (false, Rankings.Empty);
    }
    (bool, Rankings) CheckThreeOfAKind()
    {
        var toaK = hand.GroupBy(x => x.Number).OrderByDescending(x => x.Key).FirstOrDefault(x => x.Count() == 3);
        return toaK != null ? (true, Rankings.ThreeOfAKind) : (false, Rankings.Empty);
    }
    (bool, Rankings) ChecKTwoPair()
    {
        var twoPair = hand.GroupBy(x => x.Number).Where(x => x.Count() == 2);
        return twoPair.Count() >= 2 ? (true, Rankings.TwoPair) : (false, Rankings.Empty);
    }
    (bool, Rankings) CheckOnePair()
    {
        var onePair = hand.GroupBy(x => x.Number).FirstOrDefault(x => x.Count() >= 2);
        return onePair != null ? (true, Rankings.OnePair ) : (false, Rankings.Empty);
    }

    bool CheckHighCard()
    {
        hand.Sort((s1, s2) => s1.Number.CompareTo(s2.Number));
        return true;    
    }
}



