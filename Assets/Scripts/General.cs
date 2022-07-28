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
    }
}
