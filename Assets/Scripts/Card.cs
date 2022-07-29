using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public CardData cardData = null;

    public Text cardTitle = null;
    public Text cardDescription = null;
    public Text cardFaction = null;

    public Image cost = null;
    
    public Image health = null;
    public int cardHealth = 0;

    public Image damage = null;
    public int cardDamage = 0;

    public Image cardImage = null;
    public bool isDraggable = false;
    public bool isActive = false;

    public GameObject activeEffect = null;
    public GameObject playedEffect = null;
    public GameObject cardBack = null;

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

        cost.sprite = GameController.instance.costNumbers[cardData.cost];
        health.sprite = GameController.instance.healthNumbers[cardData.health];
        cardHealth = cardData.health;

        damage.sprite = GameController.instance.damageNumbers[cardData.damage];
        cardDamage = cardData.damage;
    }

    private void dealDamage(int damage)
    {
        cardHealth -= damage;

        if (cardHealth <= 0)
        {
            health.sprite = GameController.instance.healthNumbers[0];
            GameObject.Destroy(this.gameObject);
        } else
        {
            health.sprite = GameController.instance.healthNumbers[cardHealth];
        }
            
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name == "DropZone")
        {
            Debug.Log("Dropped card on card");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Card card = GetComponent<Card>();

        if (GameController.instance.playedCard == null)
        {
            if (card.isActive)
            {
                GameController.instance.playedCard = card;
                card.isActive = false;
                card.activeEffect.SetActive(false);
                card.playedEffect.SetActive(true);
            }
        } else
        {
            if (card.transform.parent.name == "DropZone")
            {
                card.dealDamage(GameController.instance.playedCard.cardDamage);
                GameController.instance.playedCard.dealDamage(card.cardDamage);
                
                GameController.instance.playedCard.playedEffect.SetActive(false);
                GameController.instance.playedCard = null;
            }
        }
    }
}
