using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Card> cards;

    public void activateCards()
    {
        foreach (Card card in cards)
        {
            if (!card.isRooted)
            {
                card.Activate(true);
            }
        }
    }

    public void deactivateCards()
    {
        foreach (Card card in cards)
        {
            card.Activate(false);
        }
    }
}