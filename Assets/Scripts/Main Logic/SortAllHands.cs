using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortAllHands : MonoBehaviour
{
     List<Player> sortedByRank;
     public void ButtonFindWinner()
     {
        List<Player> temp = new List<Player>();
        temp.AddRange(FindObjectsOfType<Player>());
        SortHandsBasedOnRanking(temp);
     }
    void SortHandsBasedOnRanking(List<Player> players)
    {
        foreach (Player player in players)
        {
            player.CheckHandResult();
        }
        sortedByRank = players.OrderBy(x => x.rankings).ToList();
    }
}
