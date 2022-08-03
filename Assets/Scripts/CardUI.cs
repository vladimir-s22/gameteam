using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameController.instance.PlayedCard = GetComponent<Card>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameController.instance.PlayedCard = null;
    }
}
