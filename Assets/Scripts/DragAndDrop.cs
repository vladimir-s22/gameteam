using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Card card = GetComponent<Card>();

        if (card.isDraggable)
            originalPosition = transform.position;
            
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Card card = GetComponent<Card>();

        if (card.isDraggable)
            transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Card card = GetComponent<Card>();

        if (card.isDraggable)
        {
            transform.position = originalPosition;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
