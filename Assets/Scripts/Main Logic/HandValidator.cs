using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class HandValidator : MonoBehaviour
{
    public Rankings CheckHandResult(List<Card> hand)
    {
        if (CheckRoyalFlush(hand).Item1) return CheckRoyalFlush(hand).Item2;
        if (CheckStraightFlush(hand).Item1) return CheckStraightFlush(hand).Item2;
        if (CheckFourOfAKind(hand).Item1) return CheckFourOfAKind(hand).Item2;
        if (CheckFullHouse(hand).Item1) return CheckFullHouse(hand).Item2;
        if (CheckFlush(hand).Item1) return CheckFlush(hand).Item2;
        if (CheckStraight(hand).Item1) return CheckStraight(hand).Item2;
        if (CheckThreeOfAKind(hand).Item1) return CheckThreeOfAKind(hand).Item2;
        if (ChecKTwoPair(hand).Item1) return ChecKTwoPair(hand).Item2;
        if (CheckOnePair(hand).Item1) return CheckOnePair(hand).Item2;

        return Rankings.HighCard;
    }
    (bool, Rankings) CheckRoyalFlush(List<Card> hand)
    {
        var straightFlush = CheckStraightFlush(hand);
        if (straightFlush.Item1)
        {
            //return straightFlush.Item3.All(x => x.Number <= 10) ? (true, Rankings.RoyalFlush) : (false, Rankings.Empty);
            foreach (var card in straightFlush.Item3)
            {
                if (card.Number < 10)
                {
                    return (false, Rankings.Empty);
                }
            }
            return (true, Rankings.RoyalFlush);
        }
        return (false, Rankings.Empty);
    }
    (bool, Rankings, IEnumerable<Card>) CheckStraightFlush(List<Card> hand)
    {
        Suit temp = Suit.HEARTS;
        for (int i = 0; i < hand.Count; i++)
        {
            if (i == 0) temp = hand[i].Suit;
            if (hand[i].Suit != temp)
            {
                return (false, Rankings.Empty, null);
            }
        }
        List<Card> flush = hand.GroupBy(x => x.Suit).Where(x => x.Count() >= 5).SingleOrDefault().ToList();
        //IEnumerable<Card> flush = hand.GroupBy(x => x.Suit).Where(x => x.Count() >= 5).SingleOrDefault() ?? Enumerable.Empty<Card>();
        var straightFlush = CheckStraight(flush).Item3;
        return straightFlush != null ? (true, Rankings.StraightFlush, straightFlush) : (false, Rankings.Empty, null);
    }
    (bool, Rankings) CheckFourOfAKind(List<Card> hand)
    {
        var fourOfAKind = hand.GroupBy(x=> x.Number).SingleOrDefault(x => x.Count() >= 4) ?? Enumerable.Empty<Card>();
        return fourOfAKind.Any() ? (true, Rankings.FourOfAKind) : (false, Rankings.Empty);
    }
    (bool, Rankings) CheckFullHouse(List<Card> hand)
    {
        var toaK = CheckThreeOfAKindWithReturn(hand);
        if (toaK.Item1)
        {
            IEnumerable<Card> remainingCards = hand.Where(x => !toaK.Item2.Any(y => y.Number == x.Number));
            IEnumerable<Card> highestTwoPair = remainingCards.GroupBy(x=>x.Number).Where(x => x.Count() >= 2).OrderByDescending(x=>x.Key).FirstOrDefault() ?? Enumerable.Empty<Card>(); ;
            if (highestTwoPair.Any())
            {
                return (true, Rankings.FullHouse);
            }
        }
        return (false, Rankings.Empty);
    }
    (bool, Rankings) CheckFlush(List<Card> hand)
    {
        var flush = hand.GroupBy(x => x.Suit).Where(x => x.Count() >= 5).SelectMany(x => x.OrderByDescending(y => y.Number).Take(5));
        return flush.Any() ? (true, Rankings.Flush) : (false, Rankings.Empty);
    }
    (bool, Rankings, IEnumerable<Card>) CheckStraight(List<Card> hand)
    {
        hand = hand.OrderBy(x=>x.Number).ToList();

        if (hand.Any())
        {
            bool isAceStraight = !new List<int>() { 14, 2, 3, 4, 5 }.Except(hand.Select(x => x.Number)).Any();
            if (isAceStraight)
            {
                return (true, Rankings.Straight, hand.Where(x => new List<int>() { 14, 2, 3, 4, 5 }.Contains(x.Number)).GroupBy(x => x.Number).Select(x => x.First()));
            }
            int? temp = null;
            int conseductiveIndex = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                if (temp.HasValue)
                {
                    if (temp != hand.ElementAt(i).Number - 1)
                    {
                        conseductiveIndex = i;
                    }
                    if (i - conseductiveIndex == 4)
                    {
                        return (true, Rankings.Straight, hand.Skip(conseductiveIndex).Take(5));
                    }
                }
                temp = hand.ElementAt(i).Number;
            }
        }
        return (false, Rankings.Empty, null);
    }
    (bool, Rankings) CheckThreeOfAKind(List<Card> hand)
    {
        var toaK = hand.GroupBy(x => x.Number).OrderByDescending(x => x.Key).FirstOrDefault(x => x.Count() == 3);
        return toaK != null ? (true, Rankings.ThreeOfAKind) : (false, Rankings.Empty);
    }
    //not the most efficient method but hindseight is 20:20
    (bool, List<Card>) CheckThreeOfAKindWithReturn(List<Card> hand)
    {
        List<Card> toaK = new List<Card>();
        var list = hand.GroupBy(x => x.Number).OrderByDescending(x => x.Key).FirstOrDefault(x => x.Count() == 3);
        if (list!=null)
        {
            toaK.AddRange(list);
        }
        return toaK.Count != 0 ? (true, toaK) : (false, toaK);
    }
    (bool, Rankings) ChecKTwoPair(List<Card> hand)
    {
        var twoPair = hand.GroupBy(x => x.Number).Where(x => x.Count() == 2);
        return twoPair.Count() >= 2 ? (true, Rankings.TwoPair) : (false, Rankings.Empty);
    }
    (bool, Rankings) CheckOnePair(List<Card> hand)
    {
        var onePair = hand.GroupBy(x => x.Number).FirstOrDefault(x => x.Count() >= 2);
        return onePair != null ? (true, Rankings.OnePair ) : (false, Rankings.Empty);
    }
}



