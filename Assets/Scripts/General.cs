using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class General : MonoBehaviour, IPointerDownHandler
{
    public Image HealthImage;
    public Image GeneralImage;

    public GameObject winScreen;
    public GameObject winBanner;

    public int _health = 20;

    public void getDamage(int damage)
    {
        if (_health > 0 && damage <= _health)
        {
            _health -= damage;
        } else
        {
            _health = 0;
        }

        HealthImage.sprite = FontContainer.instance.HealthNumbers[_health];

        if (_health == 0)
        {
            winBanner.SetActive(false);
            winScreen.SetActive(true);
        }
    }

    public void SetActiveEffect(bool active)
    {
        gameObject.transform.Find("GeneralActive").gameObject.SetActive(active);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerSwitcher.instance.GetActivePlayer().GetGeneral() == GetComponent<General>())
        {
            getDamage(6);
        }
    //     if (GameController.instance.playedCard && GameController.instance.activePlayer.general.gameObject != gameObject)
    //     {
    //         getDamage(GameController.instance.playedCard.cardDamage);
    //         GameController.instance.playedCard.playedEffect.SetActive(false);
    //         GameController.instance.playedCard = null;
    //     }

    //     if (GameController.instance.playedCard.cardData.spellType == "draw")
    //     {
    //         Card playedCard = GameController.instance.playedCard;
    //         Hand activeHand = GameController.instance.activePlayer.hand;
    //         Debug.Log("[General::onPointerDown::Draw] It's a draw card");
    //         Deck activeDeck;
    //         if (GameController.instance.activePlayer == GameController.instance.playerA)
    //         {
    //             activeDeck = GameController.instance.playerADeck;
    //         } else
    //         {
    //             activeDeck = GameController.instance.playerBDeck;
    //         }

    //         for (int i = 0; i < playedCard.cardData.health; i++)
    //         {
    //             activeDeck.dealCard(activeHand);
    //         }
    //     }

    //     if (GameController.instance.playedCard.cardData.spellType == "buff")
    //     {
    //         Debug.Log("[General::onPointerDown::Buff] It's a buff card");
    //         Card playedCard = GameController.instance.playedCard;
    //         Board activeBoard = GameController.instance.activePlayer.board;
    //         foreach(Card iterateCard in activeBoard.cards)
    //         {
    //             iterateCard.cardDamage += 1;
    //             iterateCard.damage.sprite = GameController.instance.damageNumbers[iterateCard.cardDamage];
    //         }
    //     }
    }
}
