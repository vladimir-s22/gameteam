using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class General : MonoBehaviour, IPointerDownHandler
{
    public int health = 20;
    public Image healthImage;
    public GameObject winScreen;
    public GameObject winBanner;

    public void getDamage(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            healthImage.sprite = GameController.instance.redGlowNumbers[health];
        } else
        {
            healthImage.sprite = GameController.instance.redGlowNumbers[0];
            winBanner.SetActive(false);
            winScreen.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameController.instance.playedCard && GameController.instance.activePlayer.general.gameObject != gameObject)
        {
            getDamage(GameController.instance.playedCard.cardDamage);
            GameController.instance.playedCard.playedEffect.SetActive(false);
            GameController.instance.playedCard = null;
        }

        if (GameController.instance.playedCard.cardData.spellType == "draw")
        {
            Card playedCard = GameController.instance.playedCard;
            Hand activeHand = GameController.instance.activePlayer.hand;
            Debug.Log("[General::onPointerDown::Draw] It's a draw card");
            Deck activeDeck;
            if (GameController.instance.activePlayer == GameController.instance.playerA)
            {
                activeDeck = GameController.instance.playerADeck;
            } else
            {
                activeDeck = GameController.instance.playerBDeck;
            }

            for (int i = 0; i < playedCard.cardData.health; i++)
            {
                activeDeck.dealCard(activeHand);
            }
        }

        if (GameController.instance.playedCard.cardData.spellType == "buff")
        {
            Debug.Log("[General::onPointerDown::Buff] It's a buff card");
            Card playedCard = GameController.instance.playedCard;
            Board activeBoard = GameController.instance.activePlayer.board;
            foreach(Card iterateCard in activeBoard.cards)
            {
                iterateCard.cardDamage += 1;
                iterateCard.damage.sprite = GameController.instance.damageNumbers[iterateCard.cardDamage];
            }
        }
    }
}
