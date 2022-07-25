using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardData = null;

    public Text cardTitle = null;
    public Text cardDescription = null;
    public Text cardFaction = null;

    public Image cost = null;
    public Image health = null;
    public Image damage = null;

    public Image cardImage = null;

    public void initialize()
    {
        if (cardData == null)
        {
            Debug.LogError("Card has no cardData");
            return;
        }

        cardTitle.text = cardData.cardTitle;
        cardDescription.text = cardData.cardDescription;
        cardFaction.text = cardData.cardFaction;

        cardImage.sprite = cardData.cardImage;

        cost.sprite = GameController.instance.healthNumbers[cardData.cost];
        health.sprite = GameController.instance.healthNumbers[cardData.health];
        damage.sprite = GameController.instance.healthNumbers[cardData.damage];
    }

}
