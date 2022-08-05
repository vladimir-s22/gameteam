using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerDownHandler
{
    public CardData cardData;

    [SerializeField] private Text cardTitle;
    [SerializeField] private Text cardDescription;
    [SerializeField] private Text cardFaction;

    [SerializeField] private Image cost;
    [SerializeField] private Image health;
    [SerializeField] private Image damage;
    [SerializeField] private Image cardImage;

    [SerializeField] private int cardCost = 0;
    [SerializeField] private int cardHealth = 0;
    [SerializeField] private int cardDamage = 0;
    [SerializeField] private int thorns = 0;
    [SerializeField] private int armour = 0;

    public bool isDraggable = false;
    public bool isActive = false;
    public bool isProtected = false;
    public bool isRooted = false;

    [SerializeField] private GameObject activeEffect;
    [SerializeField] private GameObject playedEffect;
    [SerializeField] private GameObject cardBack;

    public void initialize()
    {
        if (cardData == null)
        {
            Debug.LogError("Card has no cardData");
            return;
        }

        cardCost = cardData.cost;
        cardHealth = cardData.health;
        cardDamage = cardData.damage;

        thorns = cardData.thorns;
        armour = cardData.armour;

        UpdateCardVisual();
    }

    public void UpdateCardVisual()
    {
        cardTitle.text = cardData.cardTitle;
        cardDescription.text = cardData.cardDescription;
        cardFaction.text = cardData.cardFaction;

        cardImage.sprite = cardData.cardImage;
        cost.sprite = FontContainer.instance.HealthNumbers[cardCost];

        if (cardHealth < 1)
        {
            health.sprite = FontContainer.instance.HealthNumbers[0];
        }
        else
        {
            health.sprite = FontContainer.instance.HealthNumbers[cardHealth];
        }

        if (cardDamage < 1)
        {
            damage.sprite = FontContainer.instance.HealthNumbers[0];
        } else
        {
            damage.sprite = FontContainer.instance.HealthNumbers[cardDamage];
        }
    }

    private void dealDamage(int damage)
    {
        cardHealth -= damage;

        if (cardHealth <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

        UpdateCardVisual();
    }

    private void heal(int amount)
    {
        if (cardHealth + amount >= cardData.health)
        {
            cardHealth = cardData.health;
        }

        UpdateCardVisual();
    }

    public bool CanPlay()
    {
        if (cardCost <= PlayerSwitcher.instance.GetActivePlayer().GetEssence())
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void copyCard(Board cardArea)
    {
        GameObject newCard = GameObject.Instantiate(CardsContainer.instance.GetPrefab(cardData), cardArea.transform);
        Card card = newCard.GetComponent<Card>();

        card.cardData = cardData;
        card.isDraggable = false;
        card.initialize();
        cardArea.cards.Add(card);

        PlayerSwitcher.instance.GetActivePlayer().GetHand().Cards.Remove(gameObject.GetComponent<Card>());
        GameObject.Destroy(gameObject);
    }

    public void PlayCard() 
    {
        if (CanPlay())
        {
            PlayerSwitcher.instance.GetActivePlayer().SpendEssence(GetComponent<Card>().cardCost);
        }
    }

    public void Activate(bool enable)
    {
        activeEffect.SetActive(enable);
        isActive = enable;

        if (!enable)
        {
            playedEffect.SetActive(enable);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Card playedCard = GameController.instance.PlayedCard;

        if (playedCard)
        {   
            if (playedCard.cardData.isSpell && playedCard.cardData.spellType == "damage")
            {
                dealDamage(playedCard.cardData.spellPower);
                Destroy(playedCard.gameObject);
                GameController.instance.PlayedCard = null;
            } else
            {
                if (transform.parent.name == "DropZone" && playedCard != this && transform.parent.GetComponent<Board>() != playedCard.transform.parent.GetComponent<Board>())
                {
                    dealDamage(playedCard.cardDamage - armour);
                    playedCard.dealDamage(thorns);

                    if (!playedCard.cardData.isRanged)
                    {
                        if (cardData.isRanged)
                        {
                            playedCard.dealDamage(0);
                        } else
                        {
                            playedCard.dealDamage(cardDamage - armour);
                        }
                    }
                    playedCard.playedEffect.SetActive(false);
                    GameController.instance.PlayedCard = null;
                }
            }
        } 
        else
        {
            if (isActive)
            {
                GameController.instance.PlayedCard = this;
                Activate(false);
                playedEffect.SetActive(true);
            }
        }
    }

    public int GetDamage()
    {
        return cardDamage;
    }

    public void CastSpell()
    {
        Player activePlayer = PlayerSwitcher.instance.GetActivePlayer();
        Player inactivePlayer = PlayerSwitcher.instance.GetInActivePlayer();

        switch (cardData.spellType)
        {
            case "draw":
                {
                    for (int i = 0; i < cardData.spellPower; i++)
                    {
                        Destroy(gameObject);
                        int listIndex = activePlayer.GetHand().Cards.IndexOf(this);
                        activePlayer.GetHand().Cards.RemoveAt(listIndex);

                        activePlayer.Deck.dealCard(activePlayer.GetHand().gameObject);
                    }
                    break;
                }
            case "rejuvenate":
                {
                    foreach (Card card in activePlayer.GetBoard().cards)
                    {
                        card.heal(cardData.spellPower);
                    }
                    activePlayer.GetGeneral().getHeal(cardData.spellPower);
                    break;
                }
            case "damage":
                {
                    GameController.instance.PlayedCard = this;
                    break;
                }
            default: break;
        }

        if (cardData.spellType != "damage")
        {
            GameController.instance.PlayedCard = null;
        }

        if (gameObject && cardData.spellType != "damage")
        {
            Destroy(gameObject);
        }
    }
}
