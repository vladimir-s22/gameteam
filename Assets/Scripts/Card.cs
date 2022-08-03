using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//, IPointerDownHandler
{
    public CardData cardData;

    [SerializeField] private Text cardTitle;
    [SerializeField] private Text cardDescription;
    [SerializeField] private Text cardFaction;

    [SerializeField] private Image cost;
    [SerializeField] private Image health;
    [SerializeField] private Image damage;
    [SerializeField] private Image cardImage;

    private int cardCost = 0;
    private int cardHealth = 0;
    private int cardDamage = 0;
    private int thorns = 0;
    private int armour = 0;

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

        updateCardVisual();
    }

    private void updateCardVisual()
    {
        cardTitle.text = cardData.cardTitle;
        cardDescription.text = cardData.cardDescription;
        cardFaction.text = cardData.cardFaction;

        cardImage.sprite = cardData.cardImage;
        cost.sprite = FontContainer.instance.HealthNumbers[cardCost];
        health.sprite = FontContainer.instance.HealthNumbers[cardHealth];

        if (cardData.damage < 1)
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

        updateCardVisual();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameController.instance.PlayedCard = GetComponent<Card>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameController.instance.PlayedCard = GetComponent<Card>();
    }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     Card card = GetComponent<Card>();
    //     Card playedCard = GameController.instance.playedCard;


    //     if (GameController.instance.playedCard == null)
    //     {
    //         if (card.isActive)
    //         {
    //             GameController.instance.playedCard = card;
    //             card.isActive = false;
    //             card.activeEffect.SetActive(false);
    //             card.playedEffect.SetActive(true);
    //         }
    //     } else
    //     {
    //         if (playedCard.cardData.isSpell)
    //         {
    //             playedCard.castSpell(card);
    //             GameObject.Destroy(playedCard.gameObject);
    //         }

    //         if (card.transform.parent.name == "DropZone")
    //         {
    //             card.dealDamage(playedCard.cardDamage - card.armour);

    //             Debug.Log("[Card::onPointerDown::backDamageCheck] Target card has thorns: " + card.thorns);
    //             playedCard.dealDamage(card.thorns);

    //             if (!playedCard.cardData.isRanged)
    //             {
    //                 if (card.cardData.isRanged)
    //                 {
    //                     Debug.Log("[Card::onPointerDown::backDamageCheck] Target card is ranged: " + card.cardData.isRanged);
    //                     playedCard.dealDamage(0);
    //                 } else
    //                 {
    //                     Debug.Log("[Card::onPointerDown::backDamageCheck] Target card is ranged: " + card.cardData.isRanged);
    //                     playedCard.dealDamage(card.cardDamage - card.armour);
    //                 }
    //             }

    //             playedCard.playedEffect.SetActive(false);
    //             GameController.instance.playedCard = null;
    //         }
    //     }
    // }

    // public void castSpell(Card card)
    // {
    //     Card playedCard = GameController.instance.playedCard;
    //     if (playedCard.cardData.spellType == "thorn")
    //     {
    //         card.thorns += 1;
    //     }

    //     if (playedCard.cardData.spellType == "rejuvenate")
    //     {
    //         foreach (Card iterateCard in GameController.instance.activePlayer.board.cards)
    //         {
    //             Debug.Log("[Card::CastSpell::Rejuvenate] Iteratable card is " + iterateCard.cardData.cardTitle);
    //             iterateCard.dealDamage(playedCard.cardData.damage);
    //             Debug.Log("[Card::CastSpell::Rejuvenate] Iteratable card has " + iterateCard.cardHealth + " HP");
    //             Debug.Log("[Card::CastSpell::Rejuvenate] Played card deals " + playedCard.cardData.damage);
    //             iterateCard.health.sprite = GameController.instance.healthNumbers[iterateCard.cardHealth];
    //         }
    //         GameController.instance.activePlayer.general.GetComponent<General>().getDamage(playedCard.cardData.damage);
    //         GameController.instance.activePlayer.general.GetComponent<General>().healthImage.sprite = GameController.instance.redGlowNumbers[GameController.instance.activePlayer.general.GetComponent<General>().health];
    //     }

    //     if (playedCard.cardData.spellType == "root")
    //     {
    //         Board inActivePlayerBoard = getInactivePlayer().board;
    //         if (playedCard.cardData.health == 0)
    //         {
    //             card.dealDamage(playedCard.cardData.damage);
    //             Debug.Log("[Card::castSpell::root] Dealing single damage " + playedCard.cardData.damage);
    //             card.isRooted = true;
    //         } else
    //         {
    //             Board nonActivePlayerBoard = getInactivePlayer().board;
    //             Debug.Log("[Card::castSpell::root] Dealing board damage " + playedCard.cardData.damage);
    //             foreach(Card iterateCard in nonActivePlayerBoard.cards)
    //             {
    //                 iterateCard.dealDamage(playedCard.cardData.damage);
    //                 iterateCard.isRooted = true;
    //             }
    //         }
    //     }

    //     if (playedCard.cardData.spellType == "draw")
    //     {
    //         // Hand activeHand = GameController.instance.activePlayer.hand;
    //         Debug.Log("[Card::castSpell::Draw] It's a draw card");
    //         // Deck activeDeck;
    //         // if (GameController.instance.activePlayer == GameController.instance.playerA)
    //         // {
    //         //     activeDeck = GameController.instance.playerADeck;
    //         // } else
    //         // {
    //         //     activeDeck = GameController.instance.playerBDeck;
    //         // }

    //         // for (int i = 0; i < playedCard.cardData.health; i++)
    //         // {
    //         //    activeDeck.dealCard(activeHand);
    //         // }
    //     }

    //     if (playedCard.cardData.spellType == "damage")
    //     {
    //         card.dealDamage(playedCard.cardData.damage);
    //     }
    // }

    // public Player getInactivePlayer()
    // {
    //     Player activePlayer = GameController.instance.activePlayer.GetComponent<Player>();
    //     if (activePlayer == GameController.instance.playerA.GetComponent<Player>())
    //     {
    //         return GameController.instance.playerB.GetComponent<Player>();
    //     } else
    //     {
    //         return GameController.instance.playerA.GetComponent<Player>();
    //     }
    // }
}
