using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card[] Cards = new Card[7];
    public string[] AnimationNames = new string[3];
    
    public void AllowDragCards()
    {
        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i] != null)
            {
                Cards[i].AllowDrag();
            }
        }
    }

    // public void deactivateCards()
    // {
    //     Card[] cards = this.cards;

    //     for (int i = 0; i < cards.Length; i++)
    //     {
    //         if (cards[i] != null)
    //         {
    //             cards[i].isDraggable = false;
    //             cards[i].cardBack.SetActive(true);
    //         }
    //     }
    // }

    // public void moveCardtoDropZone(Card card, Board board)
    // {
    //     for (int i = 0; i < 7; i++)
    //     {
    //         if (cards[i] == card)
    //         {
    //             board.addCard(card, board);
    //             GameObject.Destroy(cards[i].gameObject);
    //         }
    //     }
    // }
}
