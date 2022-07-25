using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<CardData> cardDatas = new List<CardData>();

    public void Create()
    {
        List<CardData> cardDataList = new List<CardData>();
        foreach (CardData cardData in GameController.instance.cards)
        {
            for (int i = 0; i < cardData.numberInDeck; i++)
            {
                cardDataList.Add(cardData);
            }
        }

        while (cardDataList.Count > 0)
        {
            int randomIndex = Random.Range(0, cardDataList.Count);
            cardDatas.Add(cardDataList[randomIndex]);
            cardDataList.RemoveAt(randomIndex);
        }
    }
}
