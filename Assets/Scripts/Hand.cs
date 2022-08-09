using UnityEngine;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();

    public void AllowDragCards(bool allow)
    {
        foreach (Card card in Cards)
        {
            card.isDraggable = allow;
        }
    }

    public void UpdateGraphics()
    {
        foreach (Card card in Cards)
        {
            card.UpdateCardVisual();
        }
    }

    public void CleanHand()
    {
        for (int i = Cards.Count -1; i >= 0; i--)
        {
            if (Cards[i] == null)
            {
                Cards.RemoveAt(i);
            }
        }
    }

    public void HideHand(bool show)
    {
        foreach (Card card in Cards)
        {
            if (card.gameObject)
            {
                card.ShowBack(show);
            }
        }
    }
}
