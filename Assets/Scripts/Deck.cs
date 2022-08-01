using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<CardData> cardDatas = new List<CardData>();
    public string faction;

    public void Create()
    {
        // List<CardData> cardDataList = new List<CardData>();
        // if (faction == "eldritch")
        // {
        //     foreach (CardData cardData in GameController.instance.eldritchCards)
        //     {
        //         for (int i = 0; i < cardData.numberInDeck; i++)
        //         {
        //             cardDataList.Add(cardData);
        //         }
        //     }
        // } else
        // {
        //     foreach (CardData cardData in GameController.instance.romanCards)
        //     {
        //         for (int i = 0; i < cardData.numberInDeck; i++)
        //         {
        //             cardDataList.Add(cardData);
        //         }
        //     }
        // }

        // while (cardDataList.Count > 0)
        // {
        //     int randomIndex = Random.Range(0, cardDataList.Count);
        //     cardDatas.Add(cardDataList[randomIndex]);
        //     cardDataList.RemoveAt(randomIndex);
        // }
    }

    // private CardData RandomCard()
    // {
    //     CardData result = null;
    //     if (cardDatas.Count == 0)
    //     {
    //         Create();
    //     }

    //     result = cardDatas[0];
    //     cardDatas.RemoveAt(0);

    //     return result;
    // }

    // private Card createNewCard(GameObject cardArea)
    // {
    //     CardData newCardData;
    //     GameObject cardPrefab;

    //     newCardData = RandomCard();

    //     if (newCardData.isSpell)
    //     {
    //         if (faction == "roman")
    //         {
    //             cardPrefab = GameController.instance.romanSpellPrefab;        
    //         } else
    //         {
    //             cardPrefab = GameController.instance.eldritchSpellPrefab;
    //         }
    //     } else
    //     {
    //         if (faction == "roman")
    //         {
    //             cardPrefab = GameController.instance.romanUnitPrefab;
    //         }
    //         else
    //         {
    //             cardPrefab = GameController.instance.eldritchUnitPrefab;
    //         }
    //     }

    //     GameObject newCard = GameObject.Instantiate(cardPrefab,
    //                                                 GameController.instance.canvas.gameObject.transform);
    //     newCard.transform.SetParent(cardArea.transform, false);
    //     Card card = newCard.GetComponent<Card>();

    //     if (card)
    //     {
    //         card.cardData = newCardData;
    //         card.isDraggable = false;
    //         card.initialize();
            
    //         return card;
    //     } else
    //     {
    //         Debug.LogError("No card component found");
    //         return null;
    //     }
    // }

    internal void dealCard(Hand hand)
    {
        // Debug.Log("Length of hands array " + hand.cards.Count);
        // for (int i = 0; i < 7; i++)
        // {
        //     if (hand.cards[i] == null)
        //     {
        //         hand.cards[i] = createNewCard(hand.cardArea);
        //         return;
        //     }
        // }
    }
}
