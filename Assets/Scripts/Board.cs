using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Board : MonoBehaviour, IDropHandler
{
    public delegate void PlayedCardDelegate(Card card);
    public event PlayedCardDelegate onCardPlay;

    public List<Card> cards;

    public void activateCards(bool activate)
    {
        if (cards.Count > 0)
        {
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                if (cards[i] == null)
                {
                    cards.RemoveAt(i);
                }
                else
                {
                    if (!cards[i].isRooted)
                    {
                        cards[i].Activate(activate);
                    } else
                    {
                        cards[i].isRooted = false;
                    }
                }
            }
        }
    }

    public void DealDamage(int amount)
    {
        foreach (Card card in cards)
        {
            card.dealDamage(amount);
        }
    }

    public void RootBoard()
    {
        foreach (Card card in cards)
        {
            card.isRooted = true;
        }
    }

    public void BuffBoard(int amount, int heal)
    {
        foreach (Card card in cards)
        {
            card.BuffDamage(amount);
            card.IncreaseBaseHealth(heal);
        }
    }

    public void HealBoard(int amount)
    {
        foreach (Card card in cards)
        {
            card.Heal(amount);
        }
    }

    public void Protect()
    {
        foreach (Card card in cards)
        {
            if (card.cardData.battleCry != "protector")
            {
                card.isProtected = true;
            }
        }

        PlayerSwitcher.instance.GetActivePlayer().GetGeneral().isProtected = true;
    }

    public void RemoveProtect()
    {
        if (IfProtectorOnBoard())
        {
            foreach (Card card in cards)
            {
                card.isProtected = false;
            }

            PlayerSwitcher.instance.GetInActivePlayer().GetGeneral().isProtected = false;
        }
    }

    public bool IfProtectorOnBoard()
    {
        if (cards.Any(x=> x.cardData.battleCry == "protector"))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void UpdateGraphics()
    {
        foreach (Card card in cards)
        {
            card.UpdateCardVisual();
        }
    }

    public void summonUnit(string cardTitle)
    {
        if (cards.Count < 5)
        {
            CardData newCardData = Resources.Load(cardTitle) as CardData;

            GameObject newCard = GameObject.Instantiate(CardsContainer.instance.GetPrefab(newCardData), transform);
            Card card = newCard.GetComponent<Card>();

            card.cardData = newCardData;
            card.isActive = false;
            card.isDraggable = false;
            card.initialize();
        
            cards.Add(card);
        }
    }

    public void CleanBoard()
    {
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            if (cards[i] == null)
            {
                cards.RemoveAt(i);
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragObject = eventData.pointerDrag;
        Card card = dragObject.GetComponent<Card>();
        Board activePlayerBoard = PlayerSwitcher.instance.GetActivePlayer().GetBoard();
        Hand activePlayerHand = PlayerSwitcher.instance.GetActivePlayer().GetHand();

        if (card.CanPlay() && card.isDraggable && activePlayerBoard == this)
        {
            if (card.cardData.isSpell)
            {
                GameController.instance.PlayedCard = card;
                card.gameObject.SetActive(false);
                card.CastSpell();
                if (card.cardData.spellType != "damage" && card.cardData.spellType != "thorn" && card.cardData.spellType != "grow")
                {
                    GameController.instance.PlayedCard = null;
                }
                card.isDraggable = false;
                card.PlayCard();
            }
            else
            {
                if (cards.Count < 5)
                {
                    onCardPlay?.Invoke(card);
                    card.copyCard(this);

                    card.isDraggable = false;
                    card.PlayCard();
                }
            }
        }
    }
}