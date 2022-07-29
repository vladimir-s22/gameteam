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
        Board targetBoard = GameController.instance.activePlayer.board;
        Hand sourceHand = GameController.instance.activePlayer.hand;

        // Debug.Log("[DropZone::onDrop] Drop zone has cards " + targetBoard.cards.Count);
        if (GameController.instance.activePlayer.essence >= card.cardData.cost && card.isDraggable == true)
        {
            card.isDraggable = false;
            if (!card.cardData.isSpell)
            {
                sourceHand.moveCardtoDropZone(card, targetBoard);
            } else
            {
                GameController.instance.playedCard = card;
                card.gameObject.SetActive(false);
            }

            
            GameController.instance.activePlayer.essence -= card.cardData.cost;
            GameController.instance.updateEssence();
        }

        // Debug.Log("[DropZone::onDrop] Active player is " + GameController.instance.activePlayer);
        // Debug.Log("[DropZone::onDrop] Active player essence is " + GameController.instance.activePlayer.essence);
    }
}
