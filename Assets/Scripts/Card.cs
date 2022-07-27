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

        cost.sprite = GameController.instance.healthNumbers[cardData.cost];
        health.sprite = GameController.instance.healthNumbers[cardData.health];
        cardHealth = cardData.health;

        damage.sprite = GameController.instance.healthNumbers[cardData.damage];
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
        
        if (GameController.instance.cardDamage == -1)
        {
            if (card.isActive)
            {
                GameController.instance.cardDamage = card.cardDamage;
                card.isActive = false;
                card.activeEffect.SetActive(false);
            }
        } else
        {
            if (card.transform.parent.name == "DropZone")
            {
                card.dealDamage(cardDamage);
                GameController.instance.cardDamage = -1;
            }
        }
    }
}
