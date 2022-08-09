using System;
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
    [SerializeField] private int cardMaxHealth = 0;
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
        cardMaxHealth = cardData.health;
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

    public void dealDamage(int damage)
    {

        cardHealth -= damage;

        if (cardHealth <= 0)
        {
            if (cardData.battleCry == "protector")
            {
                GetComponentInParent<Board>().RemoveProtect();
            }

            GameObject.Destroy(this.gameObject);
        }

        UpdateCardVisual();
    }

    public void BuffDamage(int amount)
    {
        if (cardDamage == 0)
        {
            isActive = true;
            activeEffect.SetActive(true);
        }

        cardDamage += amount;
        UpdateCardVisual();
    }

    public void Heal(int amount)
    {
        if (cardHealth + amount >= cardMaxHealth)
        {
            cardHealth = cardMaxHealth;
        } else
        {
            cardHealth += amount;
        }

        UpdateCardVisual();
    }

    public void IncreaseBaseHealth(int amount)
    {
        cardHealth += amount;
        cardMaxHealth += amount;

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

        if (cardArea.IfProtectorOnBoard() && cardData.battleCry != "protector")
        {
            card.isProtected = true;
        }

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
        if (cardDamage > 0)
        {
            activeEffect.SetActive(enable);
            isActive = enable;

            if (!enable)
            {
                playedEffect.SetActive(enable);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Card playedCard = GameController.instance.PlayedCard;

        if (playedCard)
        {   
            if (playedCard.cardData.isSpell && playedCard.cardData.spellType != "thorn")
            {
                switch (playedCard.cardData.spellType)
                {
                    case "damage":
                        {
                            if (transform.parent.name == "DropZone")
                            {
                                if (playedCard.cardData.cardTitle == "Vine Whip")
                                {
                                    isRooted = true;
                                }

                                dealDamage(playedCard.cardData.spellPower);
                                Destroy(playedCard.gameObject);
                                GameController.instance.PlayedCard = null;
                            }
                            break;
                        }
                    case "root":
                        {
                            dealDamage(playedCard.cardData.spellPower);
                            isRooted = true;
                            Destroy(playedCard.gameObject);
                            GameController.instance.PlayedCard = null;
                            break;
                        }
                    case "grow":
                        {
                            IncreaseBaseHealth(playedCard.cardData.spellPower);
                            Destroy(playedCard.gameObject);
                            GameController.instance.PlayedCard = null;
                            break;
                        }
                    default: break;
                }
            } else
            {
                if (playedCard.cardData.isSpell && playedCard.cardData.spellType == "thorn")
                {
                    thorns += playedCard.cardData.spellPower;
                    Destroy(playedCard.gameObject);
                    GameController.instance.PlayedCard = null;
                    return;
                }

                if (transform.parent.name == "DropZone" && playedCard != this && transform.parent.GetComponent<Board>() != playedCard.transform.parent.GetComponent<Board>() && !isProtected)
                {
                    if (armour >= playedCard.cardDamage)
                    {
                        dealDamage(1);
                    } else
                    {
                        dealDamage(playedCard.cardDamage - armour);
                    }

                    if (playedCard.cardData.cardTitle == "Thornbush Golem")
                    {
                        isRooted = true;
                    }


                    playedCard.dealDamage(thorns);

                    if (!playedCard.cardData.isRanged)
                    {
                        if (cardData.cardTitle == "Thornbush Golem")
                        {
                            playedCard.isRooted = true;
                        }

                        if (cardData.isRanged)
                        {
                            playedCard.dealDamage(0);
                        } else
                        {
                            if (playedCard.armour >= cardDamage && cardDamage > 0)
                            {
                                playedCard.dealDamage(1);
                            } else
                            {
                                playedCard.dealDamage(cardDamage - armour);
                            }
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

    public void AddArmour(int amount)
    {
        armour += amount;
    }

    public void ShowBack(bool show)
    {
        if (gameObject)
        {
            cardBack.SetActive(show);
        }
    }

    public void CastSpell()
    {
        Player activePlayer = PlayerSwitcher.instance.GetActivePlayer();
        Player inactivePlayer = PlayerSwitcher.instance.GetInActivePlayer();

        switch (cardData.spellType)
        {
            case "draw":
                {
                    int listIndex = activePlayer.GetHand().Cards.IndexOf(this);
                    activePlayer.GetHand().Cards.RemoveAt(listIndex);

                    for (int i = 0; i < cardData.spellPower; i++)
                    {
                        activePlayer.Deck.dealCard(activePlayer.GetHand().gameObject);
                    }
                    break;
                }
            case "rejuvenate":
                {
                    activePlayer.GetBoard().HealBoard(cardData.spellPower);
                    activePlayer.GetBoard().BuffBoard(0, 1);
                    activePlayer.GetGeneral().getHeal(cardData.spellPower);
                    break;
                }
            case "damage":
                {
                    GameController.instance.PlayedCard = this;
                    break;
                }
            case "thorn":
                {
                    GameController.instance.PlayedCard = this;
                    break;
                }
            case "grow":
                {
                    GameController.instance.PlayedCard = this;
                    break;
                }
            case "buff":
                {
                    activePlayer.GetBoard().BuffBoard(cardData.spellPower, cardData.health);
                    break;
                }
            case "root":
                {
                    if (cardData.spellTarget == "multi")
                    {
                        inactivePlayer.GetBoard().DealDamage(cardData.spellPower);
                        inactivePlayer.GetBoard().RootBoard();
                    } else
                    {
                        GameController.instance.PlayedCard = this;
                    }
                    break;
                }
            case "summon":
                {
                    activePlayer.GetBoard().CleanBoard();
                    for (int i = 0; i < cardData.spellPower; i++)
                    {
                        activePlayer.GetBoard().summonUnit(cardData.summonUnit);
                    }
                    break;
                }
            default: break;
        }

        if (cardData.spellType != "damage" && cardData.spellType != "thorn" && cardData.spellType != "grow")
        {
            GameController.instance.PlayedCard = null;
        }

        if (gameObject && cardData.spellType != "damage" && cardData.spellType != "thorn" && cardData.spellType != "grow")
        {
            Destroy(gameObject);
        }
    }
}
