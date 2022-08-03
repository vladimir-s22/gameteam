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
}
