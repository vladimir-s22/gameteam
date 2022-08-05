using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Board : MonoBehaviour, IDropHandler
{
    public List<Card> cards;

    public void activateCards(bool activate)
    {
        if (cards.Count > 0)
        {
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                if (cards[i] == null)
                {
                    cards.RemoveAt(i);
                }
                else
                {
                    cards[i].Activate(activate);
                }
            }
        }
    }

    public void UpdateGraphics()
    {
        foreach (Card card in cards)
        {
            card.UpdateCardVisual();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragObject = eventData.pointerDrag;
        Card card = dragObject.GetComponent<Card>();
        Board activePlayerBoard = PlayerSwitcher.instance.GetActivePlayer().GetBoard();
        Hand activePlayerHand = PlayerSwitcher.instance.GetActivePlayer().GetHand();

        if (card.CanPlay() && card.isDraggable && activePlayerBoard == this)
        {
            card.isDraggable = false;
            if (card.cardData.isSpell)
            {
                GameController.instance.PlayedCard = card;
                card.gameObject.SetActive(false);
                card.CastSpell();
                if (card.cardData.spellType != "damage")
                {
                    GameController.instance.PlayedCard = null;
                }
            }
            else
            {
                card.copyCard(GetComponent<Board>());
            }
            card.PlayCard();
        }
    }
}