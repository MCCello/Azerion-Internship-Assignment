using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortAllHands : MonoBehaviour
{

     public void ButtonFindWinner()
     {
        List<Player> temp = new List<Player>();
        temp.AddRange(FindObjectsOfType<Player>());
        SortHandsBasedOnRanking(temp);
     }
    public void SortHandsBasedOnRanking(List<Player> players)
    {
        foreach (Player player in players)
        {
            player.CheckHandResult();
        }
        List<Player> sortedByRank = players.OrderBy(x => x.rankings).ToList();
    }
}
