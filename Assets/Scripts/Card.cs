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

    public bool isProtected = false;
    public bool isRooted = false;

    public int thorns = 0;
    public int armour = 0;

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

        // Debug.Log("[Card::Initialize] Card name is " + cardData.name);
        // Debug.Log("[Card::Initialize] Card cost is " + cardData.cost);
        // Debug.Log("[Card::Initialize] Card health is " + cardData.health);
        // Debug.Log("[Card::Initialize] Card damage is " + cardData.damage);

        cardImage.sprite = cardData.cardImage;

        cost.sprite = GameController.instance.costNumbers[cardData.cost - 1];
        health.sprite = GameController.instance.healthNumbers[cardData.health];
        cardHealth = cardData.health;

        if (cardData.damage < 0)
        {
            damage.sprite = GameController.instance.damageNumbers[0];
        } else
        {
            damage.sprite = GameController.instance.damageNumbers[cardData.damage];
        }

        thorns = cardData.thorns;
        armour = cardData.armour;
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
        Card playedCard = GameController.instance.playedCard;


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
            if (playedCard.cardData.isSpell)
            {
                playedCard.castSpell(card);
                GameObject.Destroy(playedCard.gameObject);
            }

            if (card.transform.parent.name == "DropZone")
            {
                card.dealDamage(playedCard.cardDamage - card.armour);
                
                Debug.Log("[Card::onPointerDown::backDamageCheck] Target card has thorns: " + card.thorns);
                playedCard.dealDamage(card.thorns);

                if (!playedCard.cardData.isRanged)
                {
                    if (card.cardData.isRanged)
                    {
                        Debug.Log("[Card::onPointerDown::backDamageCheck] Target card is ranged: " + card.cardData.isRanged);
                        playedCard.dealDamage(0);
                    } else
                    {
                        Debug.Log("[Card::onPointerDown::backDamageCheck] Target card is ranged: " + card.cardData.isRanged);
                        playedCard.dealDamage(card.cardDamage - card.armour);
                    }
                }

                playedCard.playedEffect.SetActive(false);
                GameController.instance.playedCard = null;
            }
        }
    }

    public void castSpell(Card card)
    {
        Card playedCard = GameController.instance.playedCard;
        if (playedCard.cardData.spellType == "thorn")
        {
            card.thorns += 1;
        }

        if (playedCard.cardData.spellType == "rejuvenate")
        {
            foreach (Card iterateCard in GameController.instance.activePlayer.board.cards)
            {
                Debug.Log("[Card::CastSpell::Rejuvenate] Iteratable card is " + iterateCard.cardData.cardTitle);
                iterateCard.dealDamage(playedCard.cardData.damage);
                Debug.Log("[Card::CastSpell::Rejuvenate] Iteratable card has " + iterateCard.cardHealth + " HP");
                Debug.Log("[Card::CastSpell::Rejuvenate] Played card deals " + playedCard.cardData.damage);
                iterateCard.health.sprite = GameController.instance.healthNumbers[iterateCard.cardHealth];
            }
            GameController.instance.activePlayer.general.GetComponent<General>().getDamage(playedCard.cardData.damage);
            GameController.instance.activePlayer.general.GetComponent<General>().healthImage.sprite = GameController.instance.redGlowNumbers[GameController.instance.activePlayer.general.GetComponent<General>().health];
        }

        if (playedCard.cardData.spellType == "root")
        {
            Board inActivePlayerBoard = getInactivePlayer().board;
            if (playedCard.cardData.health == 0)
            {
                card.dealDamage(playedCard.cardData.damage);
                Debug.Log("[Card::castSpell::root] Dealing single damage " + playedCard.cardData.damage);
                card.isRooted = true;
            } else
            {
                Board nonActivePlayerBoard = getInactivePlayer().board;
                Debug.Log("[Card::castSpell::root] Dealing board damage " + playedCard.cardData.damage);
                foreach(Card iterateCard in nonActivePlayerBoard.cards)
                {
                    iterateCard.dealDamage(playedCard.cardData.damage);
                    iterateCard.isRooted = true;
                }
            }
        }

        if (playedCard.cardData.spellType == "draw")
        {
            // Hand activeHand = GameController.instance.activePlayer.hand;
            Debug.Log("[Card::castSpell::Draw] It's a draw card");
            // Deck activeDeck;
            // if (GameController.instance.activePlayer == GameController.instance.playerA)
            // {
            //     activeDeck = GameController.instance.playerADeck;
            // } else
            // {
            //     activeDeck = GameController.instance.playerBDeck;
            // }

            // for (int i = 0; i < playedCard.cardData.health; i++)
            // {
            //    activeDeck.dealCard(activeHand);
            // }
        }

        if (playedCard.cardData.spellType == "damage")
        {
            card.dealDamage(playedCard.cardData.damage);
        }
    }

    public Player getInactivePlayer()
    {
        Player activePlayer = GameController.instance.activePlayer.GetComponent<Player>();
        if (activePlayer == GameController.instance.playerA.GetComponent<Player>())
        {
            return GameController.instance.playerB.GetComponent<Player>();
        } else
        {
            return GameController.instance.playerA.GetComponent<Player>();
        }
    }
}
