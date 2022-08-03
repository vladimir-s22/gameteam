using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragObject = eventData.pointerDrag;
        Card card = dragObject.GetComponent<Card>();
        Board activePlayerBoard = PlayerSwitcher.instance.GetActivePlayer().GetBoard();
        Hand activePlayerHand = PlayerSwitcher.instance.GetActivePlayer().GetHand();

        if (card.CanPlay() && card.isDraggable)
        {
            card.isDraggable = false;
            if (card.cardData.isSpell)
            {
                GameController.instance.PlayedCard = card;
                card.gameObject.SetActive(false);
            } else
            {
                card.copyCard(GetComponent<Board>());
            }
            card.PlayCard();
        }
    }
}
