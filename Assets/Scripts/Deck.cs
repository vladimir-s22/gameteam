using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<CardData> CardDatas = new List<CardData>();
    private CardsContainer _cardsContainer = CardsContainer.instance;
    private GameController _gameController = GameController.instance;

    public void Create(string faction)
    {
        List<CardData> cardDataList = new List<CardData>();
        if (faction == "eldritch")
        {
            foreach (CardData cardData in _cardsContainer.GetEldritchCards())
            {
                for (int i = 0; i < cardData.numberInDeck; i++)
                {
                    cardDataList.Add(cardData);
                }
            }
        } else
        {
            foreach (CardData cardData in _cardsContainer.GetRomanCards())
            {
                for (int i = 0; i < cardData.numberInDeck; i++)
                {
                    cardDataList.Add(cardData);
                }
            }
        }

        while (cardDataList.Count > 0)
        {
            int randomIndex = Random.Range(0, cardDataList.Count);
            CardDatas.Add(cardDataList[randomIndex]);
            cardDataList.RemoveAt(randomIndex);
        }
    }

    private CardData getRandomCard()
    {
        CardData result;
        result = CardDatas[0];
        CardDatas.RemoveAt(0);
        return result;
    }

    private Card createNewCard(GameObject Hand)
    {
        CardData newCardData;

        newCardData = getRandomCard();

        GameObject newCard = GameObject.Instantiate(_cardsContainer.GetPrefab(newCardData), Hand.transform);
        Card card = newCard.GetComponent<Card>();

        if (card)
        {
            card.cardData = newCardData;
            card.isDraggable = false;
            card.initialize();
            Hand.GetComponent<Hand>().Cards.Add(card);
            
            return card;
        } else
        {
            Debug.LogError("[Deck::createNewCard] No card component found");
            return null;
        }
    }

    internal void dealCard(GameObject Hand)
    {
        if (Hand.GetComponent<Hand>().Cards.Count < 7)
        {
            createNewCard(Hand);
        }
    }
}
