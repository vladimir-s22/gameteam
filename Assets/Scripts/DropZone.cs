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

        if (GameController.instance.activePlayer.essence >= card.cardData.cost)
        {
            card.transform.SetParent(gameObject.transform, false);

            GameController.instance.activePlayer.essence -= card.cardData.cost;
            GameController.instance.updateEssence();
        }

        Debug.Log("    [DropZone::onDrop] Active player is " + GameController.instance.activePlayer);
        Debug.Log("    [DropZone::onDrop] Active player essence is " + GameController.instance.activePlayer.essence);
    }
}
