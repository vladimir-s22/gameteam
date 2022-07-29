using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board
{
    public GameObject boardArea = null;
    public List<Card> cards;

    public void addCard(Card card, Board board)
    {
        GameObject targetBoardArea = board.boardArea;
        // Debug.Log("[Board::addCard] Board is " + board);
        // Debug.Log("[Board::addCard] BoardArea is " + board.boardArea);
        cards.Add(createCard(card, targetBoardArea));
    }

    private Card createCard(Card card, GameObject targetBoardArea)
    {
        GameObject newCard = GameObject.Instantiate(GameController.instance.cardPrefab,
                                                    GameController.instance.canvas.gameObject.transform);

        newCard.transform.SetParent(targetBoardArea.transform, false);
        Card createdCard = newCard.GetComponent<Card>();

        if (createdCard)
        {
            createdCard.cardData = card.cardData;
            createdCard.isDraggable = false;
            createdCard.initialize();

            return createdCard;
        }
        else
        {
            Debug.LogError("[Board::createCard] No card component found");
            return null;
        }
    }

    public void activateCards()
    {
        foreach (Card card in cards)
        {
            if (card != null)
            {
                card.isActive = true;
                card.activeEffect.SetActive(true);
            }
        }
    }

    public void deactivateCards()
    {
        foreach (Card card in cards)
        {
            if (card != null)
            {
                card.isActive = false;
                card.activeEffect.SetActive(false);
            }
        }
    }
}
