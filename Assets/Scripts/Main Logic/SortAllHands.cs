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
            player.SortHand();
        }
        sortedByRank = players.OrderBy(x => x.rankings).ThenByDescending(x => x.hand[0].Number).ToList();

        AnnounceWinner(players);
    }
    public void AnnounceWinner(List<Player> players)
    {
        List<SpawnCards> spawnCards = new List<SpawnCards>();
        spawnCards = FindObjectsOfType<SpawnCards>().ToList();
        
        foreach (SpawnCards s in spawnCards)
        {
            if (s.player == sortedByRank[0])
            {
                s.TextChanger.textInput = "!!!!!!!Winner!!!!!!!";
            }
        }
    }
}
