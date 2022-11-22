using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCards : MonoBehaviour
{
    public Player player;
    public List<ScriptableCard> cards;
    List<Image> spriteCards;

    public void ShowHand()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spriteCards = GetComponentsInChildren<Image>().ToList();

        for (int i = 0; i < player.hand.Count; i++)
        {
            ScriptableCard c = cards.Find(x => x.Number == player.hand[i].Number && x.Suit == player.hand[i].Suit);

            spriteCards[i].sprite = c.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
